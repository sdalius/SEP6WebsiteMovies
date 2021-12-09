using MoviesWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebsite.Services
{
    public interface IUserService
    {
        List<Movie> GetTopNumMovies(int numOfMovies);
        int LogIn(string username1, string password1);
        bool isLoggedIn();
        void Logout();
        int Register(string username1, string password1);
    }
}
