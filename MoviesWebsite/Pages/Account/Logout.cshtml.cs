using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebsite.Services;

namespace MoviesWebsite.Account
{
    public class LogoutModel : PageModel
    {
        private IUserService _userService { get; }

        public LogoutModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
            _userService.Logout();
        }
    }
}
