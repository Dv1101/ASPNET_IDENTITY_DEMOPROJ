using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ASP_IDENTITY.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential credential { get; set; } = new Credential();
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid) return Page();

            //Verify Pass
            if(credential.UserName == "admin" &&  credential.Password == "admin123")
            {
                //Generate security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "dhruvvaria1101@gmail.com"),
                    new Claim("Department", "HR"),
                    new Claim("Admin", "true")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                var authProperty = new AuthenticationProperties
                {
                    IsPersistent = credential.RememberMe
                };

                await HttpContext.SignInAsync("MyCookieAuth", principal, authProperty);

                return RedirectToPage("/Index");

            }

            return Page();
        }

        public class Credential
        {
            [Required]
            [Display(Name = "User Name")]
            public string UserName { get; set; } = String.Empty;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = String.Empty;

            [Display(Name = "Remember Me")]
            public bool RememberMe { get; set; }
        }
    }
}
