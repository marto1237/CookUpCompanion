using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookUp_Companion_web.Pages
{
    public class IngredientsModel : PageModel
    {
        public List<Ingredient> Ingredients;
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public const int PageSize = 25;

        private readonly IRecipeManager recipeManager;
        public IngredientsModel(IRecipeManager recipeManager)
        {
            
            this.recipeManager = recipeManager;
        }
        public void OnGet(int? pageNum)
        {
            CurrentPage = pageNum ?? 1;
            GetIngredients(CurrentPage);
        }

        public void GetIngredients(int page)
        {
            try
            {
                Ingredients =  recipeManager.GetAllIngredients(CurrentPage, PageSize);
                TotalPages = recipeManager.GetAllIngredientsPageNum(PageSize);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
