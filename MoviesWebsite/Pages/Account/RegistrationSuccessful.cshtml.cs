using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MoviesWebsite.Pages.Account
{
    public class RegistrationSuccessfulModel : PageModel
    {
        public void OnGet()
        {
        }
        public RedirectResult OnPost()
        {
            Thread.Sleep(5000);
            return Redirect("/Account/Login");
        }
    }
}
