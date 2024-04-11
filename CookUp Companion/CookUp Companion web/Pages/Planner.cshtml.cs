using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookUp_Companion_web.Pages
{
    [Authorize]
    public class PlannerModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
