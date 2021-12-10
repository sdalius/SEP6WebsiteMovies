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
        public IUserService _userService { get; set; }

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("JWToken") != null)
            {
                MovieList = _userService.GetTopNumMovies(HttpContext.Session.GetString("JWToken"), 10);
            }
        }
        public void OnPostToken()
        {

        }
    }
}
