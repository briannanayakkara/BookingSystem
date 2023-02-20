using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleBooking.Models;

namespace SimpleBooking.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginViewModel Login { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Authenticate the user
            // If successful, redirect to the home page
            // Otherwise, return an error message to the login page

            return Page();
        }
    }
}
