using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebsite.Models;
using MoviesWebsite.Services;

namespace MoviesWebsite.Pages.Statistics.DecadeComparison
{
    public class DecadeComparisonModel : PageModel
    {
        [BindProperty]
        [Required]
        public int year1 { get; set; }

        [BindProperty]
        [Required]
        public int year2 { get; set; }

        public DecadeRating decadeRating1 { get; set; }
        public DecadeRating decadeRating2 { get; set; }
        public IUserService _userService { get; set; }

        public DecadeComparisonModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }
        public void OnPostGetDecadeRatings()
        {
            if (HttpContext.Session.GetString("JWToken") != null && year1 > 0 && year2 > 0)
            {
                decadeRating1 = _userService.CompareMoviesByDecades(HttpContext.Session.GetString("JWToken"), year1);
                decadeRating2 = _userService.CompareMoviesByDecades(HttpContext.Session.GetString("JWToken"), year2);
            }
        }
    }
}
