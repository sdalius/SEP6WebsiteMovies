using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebsite.Models;
using MoviesWebsite.Services;

namespace MoviesWebsite.Pages.Statistics
{
    public class ActorMovieAverageRatingModel : PageModel
    {
        [BindProperty]
        public string name { get; set; }

        public List<Person> personList { get; set; }
        public IUserService _userService { get; set; }

        public ActorMovieAverageRatingModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("JWToken") != null)
            {
                personList = _userService.ReturnNumberOfStars(HttpContext.Session.GetString("JWToken"), 10);
            }
        }
        public void OnPostFindStarByName()
        {
            if (HttpContext.Session.GetString("JWToken") != null)
            {
                personList = _userService.GetStarsAccordingToName(HttpContext.Session.GetString("JWToken"), name);
            }
        }
    }
}
