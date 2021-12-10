using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        public string Username1 { get; set; }

        [BindProperty]
        public string Password1 { get; set; }

        public string Msg { get; set; }

        public IUserService _userService { get; set; }

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogInAsync()
        {
            Users response = await _userService.LogInAsync(Username1, Password1);
            if (response != null)
            {
                HttpContext.Session.SetString("userId", response.userID.ToString());
                HttpContext.Session.SetString("username", response.username);
                HttpContext.Session.SetString("JWToken", response.Token);
                return RedirectToPage("../Index");
            }
            Msg = "Wrong username or password. Or server is not functioning at this time.";
            return Page();
        }
    }
}
