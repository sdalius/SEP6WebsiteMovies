using MoviesWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebsite.Services
{
    public interface IUserService
    {
        List<Movie> GetTopNumMovies(string Token, int numOfMovies);
        Task<Users> LogInAsync(string username1, string password1);
        Task<int> Register(string username1, string password1);
    }
}
