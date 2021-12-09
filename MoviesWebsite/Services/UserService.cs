using Microsoft.Extensions.Options;
using MoviesWebsite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MoviesWebsite.Services
{
    public class UserService : IUserService
    {
        public HttpClient _httpClient { get; }
        public AppSettings _appSettings { get; }
        private User _user { get; set; }

        public UserService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _httpClient = httpClient;
        }

        public int LogIn(string username1, string password1)
        {
            _user = new User();

            var RequestBody = new { username = username1, password = password1 };
            var stringContent = new StringContent(JsonConvert.SerializeObject(RequestBody), Encoding.UTF8, "application/json");
            var tokenResponse = _httpClient.PostAsync(_appSettings.APIWebsite + "/Movies/login", stringContent).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var JsonContent = tokenResponse.Content.ReadAsStringAsync().Result;
                _user = JsonConvert.DeserializeObject<User>(JsonContent);
                return (int)tokenResponse.StatusCode;
            }
            else
            {
                return (int)tokenResponse.StatusCode;
            }
        }

        public int Register(string username1, string password1)
        {
            var registerModel = new RegistrationModel { Username = username1, Password = password1 };
            var stringContent = new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, "application/json");
            var tokenResponse = _httpClient.PostAsync(_appSettings.APIWebsite + "/Movies/register", stringContent).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return (int)tokenResponse.StatusCode;
            }
            else
            {
                return (int)tokenResponse.StatusCode;
            }
        }
        public List<Movie> GetTopNumMovies(int numOfMovies)
        {
            if (_user == null || _user.Token == "")
            {
                return null;
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _user.Token);
            var APIResponse = _httpClient.GetAsync(_appSettings.APIWebsite + "/Movies/ReturnTopNumberOfMovies/?numOfMovies=" + numOfMovies).Result;
            if (APIResponse.IsSuccessStatusCode)
            {
                var JsonContent = APIResponse.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Movie>>(JsonContent);
            }
            else
            {
                Console.WriteLine("APIResponse, Error : " + APIResponse.StatusCode);
                return null;
            }
        }

        public void Logout()
        {
            _user = null;
        }

        public bool isLoggedIn()
        {
            if (_user == null || _user.Token == "")
            {
                
                return false;
            }
            Console.WriteLine(_user.Token);
            return true;
        }



    }
}
