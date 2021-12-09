using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebsite.Models;
using MoviesWebsite.Services;
using Newtonsoft.Json;

namespace MoviesWebsite.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }
        private IUserService _userService { get; }

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            int returnCode = _userService.LogIn(Username, Password);
            if (returnCode == 200)
            {
                return RedirectToPage("../Index");
            }
            else
            {
                Msg = "Account does not exist or the server is down.";
            }
            return Page();
        }
    }
}
