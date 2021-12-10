using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MoviesWebsite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebsite.Services
{
    public class UserService : IUserService
    {
        public async Task<Users> LogInAsync(string username1, string password1)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://movieapisep6.azurewebsites.net/Movies/");

            var login = await hc.PostAsJsonAsync("login", new UserLogin { Username = username1, Password = password1 });
            
            if (login.IsSuccessStatusCode)
            {
                Users finallytoken = await login.Content.ReadFromJsonAsync<Users>();
                return finallytoken;
            }
            else
            {
                return null;
            } 
        }
        public async Task<int> Register(string username1, string password1)
        {
            HttpClient hc = new HttpClient();
            var registerModel = new RegistrationModel { Username = username1, Password = password1 };
            var stringContent = new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, "application/json");
            var tokenResponse = await hc.PostAsync("https://movieapisep6.azurewebsites.net" + "/Movies/register", stringContent);
            if (tokenResponse.IsSuccessStatusCode)
            {
                return (int)tokenResponse.StatusCode;
            }
            else
            {
                return (int)tokenResponse.StatusCode;
            }
        }
        public List<Movie> GetTopNumMovies(string Token, int numOfMovies)
        {
            HttpClient hc = new HttpClient();
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var APIResponse = hc.GetAsync("https://movieapisep6.azurewebsites.net" + "/Movies/ReturnTopNumberOfMovies/?numOfMovies=" + numOfMovies).Result;
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
    }
}
