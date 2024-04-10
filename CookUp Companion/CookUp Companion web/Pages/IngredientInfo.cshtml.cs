using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CookUp_Companion_web.Pages
{
    public class IngredientInfoModel : PageModel
    {
		public Ingredient ingredient;

		// Property to hold the selected unit
		[BindProperty]
		public string SelectedUnit { get; set; }

		private readonly IRecipeManager recipeManager;
		public IngredientInfoModel(IRecipeManager recipeManager)
		{

			this.recipeManager = recipeManager;
		}
		public void OnGet(string ? name)
		{
			if (name == null || name == "")
			{
				ModelState.AddModelError("error", "name is required");
				return;
			}

			GetIngredient(name);
		}

		public void GetIngredient(string ? name)
		{
			try
			{
				ingredient = recipeManager.GetIngredientByName(name);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("ERROR", ex.Message);
			}
		}
	}
}

