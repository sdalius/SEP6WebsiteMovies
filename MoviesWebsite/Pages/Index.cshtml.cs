using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebsite.Models;
using MoviesWebsite.Services;
using System.Collections.Generic;

namespace MoviesWebsite.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string SearchString { get; set; }
        public string Msg { get; set; }
        public List<Movie> MovieList { get; set; }
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
        public void OnPostFindMovie()
        {
            if (HttpContext.Session.GetString("JWToken") != null)
            {
                MovieList = _userService.GetMoviesAccordingToName(HttpContext.Session.GetString("JWToken"), SearchString);
            }
        }
        public ActionResult OnPostAddMovieToTopList(int movie_id)
        {
            if (HttpContext.Session.GetString("JWToken") != null)
            {
               var result =  _userService.AddToToptierListAsync(HttpContext.Session.GetString("JWToken"), movie_id);
               if (result.Result == 200)
               {
                   return RedirectToPage("/Index");
               }
            }
            Msg = "Error.";
            return RedirectToPage("/Index");
        }
    }
}
