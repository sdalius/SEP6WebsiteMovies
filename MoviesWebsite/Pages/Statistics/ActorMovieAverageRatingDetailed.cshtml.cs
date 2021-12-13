using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebsite.Models;
using MoviesWebsite.Services;

namespace MoviesWebsite.Pages.Statistics
{
    public class ActorMovieAverageRatingDetailedModel : PageModel
    {
        public IUserService _userService;
        public StarRating personInfo { get; set; }

        public ActorMovieAverageRatingDetailedModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet(int personId)
        {
            Console.WriteLine(personId);
            if (HttpContext.Session.GetString("JWToken") != null)
            {
                personInfo = _userService.StarRatingOfAllMoviesAsync(HttpContext.Session.GetString("JWToken"), personId);
            }
        }

        public ActionResult OnPostLogin()
        {
            return RedirectToPage("/Account/Login");
        }

        public ActionResult OnPostBack()
        {
            return RedirectToPage("/ActorMovieAverageRating");
        }
    }
}
