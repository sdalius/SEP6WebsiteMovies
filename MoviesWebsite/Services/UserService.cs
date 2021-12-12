using MoviesWebsite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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
            return null;
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
            return (int)tokenResponse.StatusCode;
        }
        public List<Movie> GetTopNumMovies(string Token, int numOfMovies)
        {
            if (Token == null || numOfMovies <= 0)
            {
                return null;
            }

            HttpClient hc = new HttpClient();
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var APIResponse = hc.GetAsync("https://movieapisep6.azurewebsites.net" + "/Movies/ReturnTopNumberOfMovies/?numOfMovies=" + numOfMovies).Result;
            if (APIResponse.IsSuccessStatusCode)
            {
                var JsonContent = APIResponse.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Movie>>(JsonContent);
            }
            Console.WriteLine("APIResponse, Error : " + APIResponse.StatusCode);
            return null;
        }

        public List<Movie> GetMoviesAccordingToName (string Token, string name)
        {
            if (Token == null || name == null || name == "")
            {
                return null;
            }
            HttpClient hc = new();
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var APIResponse = hc.GetAsync("https://movieapisep6.azurewebsites.net/Movies/GetMoviesByTitle/?title=" + name).Result;
            if (APIResponse.IsSuccessStatusCode)
            {
                var JsonContent = APIResponse.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Movie>>(JsonContent);
            }
            Console.WriteLine("APIResponse, Error : " + APIResponse.StatusCode);
            return null;
        }

        public MoviesDetailed GetMovieAccordingToID(string Token, int id)
        {
            if (Token == null || id < 0)
            {
                return null;
            }
            HttpClient hc = new();
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var APIResponse = hc.GetAsync("https://movieapisep6.azurewebsites.net/Movies/GetAMovieAccordingToID/?id=" + id).Result;
            if (APIResponse.IsSuccessStatusCode)
            {
                var JsonContent = APIResponse.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<MoviesDetailed>(JsonContent);
            }
            Console.WriteLine("APIResponse, Error : " + APIResponse.StatusCode);
            return null;
        }

        public List<Movie> GetToptierList(string Token)
        {
            if (Token == null)
            {
                return null;
            }
            HttpClient hc = new();
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var APIResponse = hc.GetAsync("https://movieapisep6.azurewebsites.net/Movies/GetToptierList").Result;
            if (APIResponse.IsSuccessStatusCode)
            {
                var JsonContent = APIResponse.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Movie>>(JsonContent);
            }
            Console.WriteLine("APIResponse, Error : " + APIResponse.StatusCode);
            return null;
        }

        public async Task<int> AddToToptierListAsync(string Token, int movieId)
        {
            HttpClient hc = new HttpClient();
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var movieModel = new Movie { Id = movieId };
            var stringContent = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
            var tokenResponse = await hc.PostAsync("https://movieapisep6.azurewebsites.net" + "/Movies/AddMovieToTierlist", stringContent);
            return (int)tokenResponse.StatusCode;
        }

        public async Task<int> RemoveMovieFromTierlist(string Token, int movieId)
        {
            HttpClient hc = new HttpClient();
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var movieModel = new Movie { Id = movieId };
            var stringContent = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
            var tokenResponse = await hc.PostAsync("https://movieapisep6.azurewebsites.net" + "/Movies/RemoveMovieFromTierlist", stringContent);
            return (int)tokenResponse.StatusCode;
        }
    }
}
