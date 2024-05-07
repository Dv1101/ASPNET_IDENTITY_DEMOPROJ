using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_IDENTITY.Pages
{
    [Authorize(Policy = "MustBePartOfHRDept")]
    public class HumanResourceModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
