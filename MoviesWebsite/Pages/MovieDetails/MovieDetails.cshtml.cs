using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebsite.Models;
using MoviesWebsite.Services;

namespace MoviesWebsite.Pages.MovieDetails
{
    public class MovieDetailsModel : PageModel
    {
        public IUserService _userService;
        public MoviesDetailed movieInfo;

        public MovieDetailsModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet(int sendId)
        {
            if (HttpContext.Session.GetString("JWToken") != null)
            {
               movieInfo = _userService.GetMovieAccordingToID(HttpContext.Session.GetString("JWToken"), sendId);
            }
        }

        public ActionResult OnPostLogin()
        {
            return RedirectToPage("/Account/Login");
        }

        public ActionResult OnPostBack()
        {
            return RedirectToPage("/index");

        }
    }
}
