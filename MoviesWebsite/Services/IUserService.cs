using MoviesWebsite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesWebsite.Services
{
    public interface IUserService
    {
        List<Movie> GetTopNumMovies(string Token, int numOfMovies);
        Task<Users> LogInAsync(string username1, string password1);
        Task<int> Register(string username1, string password1);
        List<Movie> GetMoviesAccordingToName(string Token, string name);
        MoviesDetailed GetMovieAccordingToID(string Token, int id);
        List<Movie> GetToptierList(string Token);
        Task<int> AddToToptierListAsync(string Token, int movieId);
        Task<int> RemoveMovieFromTierlist(string getString, int movieId);
    }
}
