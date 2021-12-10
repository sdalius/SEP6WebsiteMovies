using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebsite.Models;
using MoviesWebsite.Services;

namespace MoviesWebsite.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string errorMessage { get; set; }
        [BindProperty]
        public string successMessage { get; set; }

        [BindProperty]
        public RegistrationModel registerUser { get; set; }
        [BindProperty]
        public string passwordAgain { get; set; }
        private IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            Console.WriteLine(registerUser.Password + passwordAgain);
            if (registerUser.Password != passwordAgain)
            {
                errorMessage = "Passwords doesn't match, please type the right passwords again";
                return Page();
            }
            if (registerUser.Username == null)
            {
                return Page();
            }
            if (registerUser.Password == null)
            {
                return Page();
            }

            var responseCode = _userService.Register(registerUser.Username, registerUser.Password);
            if (responseCode.Result == 200)
            {
                successMessage = "Sign up successfully, back to login page";
                return RedirectToPage("/Account/RegistrationSuccessful");
            }

            errorMessage = "Username already exists or other error";
            return Page();
        }

    }
}
