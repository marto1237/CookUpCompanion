using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookUp_Companion_web.Pages
{
    [Authorize]
    public class SavedModel : PageModel
    {
        private readonly ILogger<SavedModel> _logger;

        public SavedModel(ILogger<SavedModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
