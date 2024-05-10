using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookUp_Companion_web.Pages
{
    public class _MoreOptions : PageModel
    {
        public int CurrentRecipeId { get; set; }
        public void OnGet()
        {
        }
    }
}
