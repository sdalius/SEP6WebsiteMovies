using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebsite.Models;
using MoviesWebsite.Services;

namespace MoviesWebsite.Pages
{
    public class MyToplistModel : PageModel
    {
        [BindProperty]
        public string SearchString { get; set; }
        public string Msg { get; set; }
        public IUserService _userService { get; set; }
        public List<Movie> TearListMovies { get; set; }

        public MyToplistModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("JWToken") != null)
            {
                TearListMovies = _userService.GetToptierList(HttpContext.Session.GetString("JWToken"));
            }
        }

        public ActionResult OnPostRemoveMovieFromToplist(int movie_id)
        {
            if (HttpContext.Session.GetString("JWToken") != null)
            {
                var result = _userService.RemoveMovieFromTierlist(HttpContext.Session.GetString("JWToken"), movie_id);
                if (result.Result == 200)
                {
                    return RedirectToPage("/MyToplist");
                }
            }
            Msg = "Error.";
            return RedirectToPage("/MyToplist");
        }
    }
}
