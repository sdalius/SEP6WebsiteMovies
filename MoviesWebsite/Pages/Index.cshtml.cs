using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MoviesWebsite.Models;
using MoviesWebsite.Services;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MoviesWebsite.Pages
{
    public class IndexModel : PageModel
    {
        public string Msg { get; set; }
        public List<Movie> MovieList { get; set; }
        public bool bIsLoggedIn { get; set; } = false;

        private IUserService _userService { get; }

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
            bIsLoggedIn = _userService.isLoggedIn();
            Console.WriteLine("Should be false" + bIsLoggedIn);
            if (bIsLoggedIn)
            {
                MovieList = _userService.GetTopNumMovies(10);
                Console.WriteLine("Should be true" + bIsLoggedIn);
            }
        }
        public IActionResult Logout()
        {
            return RedirectToPage("Login");
        }
    }
}
