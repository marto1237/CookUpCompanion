
using CookUp_Companion_BusinessLogic.InterfacesLL;
using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Security.Claims;

namespace CookUp_Companion_web.Pages
{
    public class RecipeModel : PageModel
    {
        public List<Recipe> Recipes;
        public List<bool> IsFavorite;
        public List<int> Likes { get; set; }
        public List<int> Dislikes { get; set; }
        public List<int> SaveCounts { get; set; }
        public List<double> Score { get; set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public string SearchText { get; set; }
        public const int PageSize = 24;

        private readonly IRecipeManager recipeManager;
        private readonly IUserManager userManager;
        private readonly IRecommendedRecipesAlgoritam recommendedRecipesAlgoritam;

        public User _user { get; private set; }

        public string sortOrder { get; set; }
        public RecipeModel(IUserManager userManager, IRecipeManager recipeManager, IRecommendedRecipesAlgoritam recommendedRecipesAlgoritam)
        {
            this.userManager = userManager;
            this.recipeManager = recipeManager;
            this.recommendedRecipesAlgoritam = recommendedRecipesAlgoritam;
        }
        public IActionResult OnGet(int? pageNum, string sortOrder)
        {
            CurrentPage = pageNum ?? 1;
            this.sortOrder = sortOrder ?? "";
            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);

            }
            //  Redirects to the login page  if "recommended" is selected and user is not authenticated
            if (sortOrder == "recommended" && !User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Login");
            }

            ViewData["CurrentSort"] = sortOrder;
            Recipes = GetSortedRecipes(sortOrder, CurrentPage, PageSize);
            TotalPages = recipeManager.GetAllRecipesPageNum(PageSize);
            PopulateRecipeInteractionData();

            return Page();
        }

        private void PopulateRecipeInteractionData()
        {
            IsFavorite = new List<bool>();
            Likes = new List<int>();
            Dislikes = new List<int>();
            Score = new List<double>();
            SaveCounts = new List<int>();

            if (_user != null)
            {
                int userId = userManager.GetIdByUsername(_user.Username);
                foreach (var recipe in Recipes)
                {
                    int recipeID = recipeManager.GetRecipeID(recipe);
                    IsFavorite.Add(recipeManager.CheckIfFavorite(userId, recipeID));
                    PopulateInteractionStats(recipeID);
                }
            }
            else
            {
                foreach (var recipe in Recipes)
                {
                    IsFavorite.Add(false); // Not logged in, cannot have favorites
                    PopulateInteractionStats(recipeManager.GetRecipeID(recipe));
                }
            }
        }

        private void PopulateInteractionStats(int recipeID)
        {
            var (likes, dislikes) = recipeManager.GetLikesAndDislikes(recipeID);
            Likes.Add(likes);
            Dislikes.Add(dislikes);
            int totalVotes = likes + dislikes;
            Score.Add(totalVotes > 0 ? (double)likes / totalVotes * 100 : 0);
            SaveCounts.Add(recipeManager.GetSaveCount(recipeID));
        }
        public void GetIngredients(int page)
        {
            try
            {
                Recipes = recipeManager.GetAllRecipes(CurrentPage, PageSize);
                TotalPages = recipeManager.GetAllRecipesPageNum(PageSize);
            }
            catch (Exception ex)
            {

                // Add a model error that you can display in the view
                ModelState.AddModelError("", $"Failed to load recipes: {ex.Message}"); 
                return;
            }


        }
        public int GetRecipeID(Recipe recipe)
        {
            int recipeID = recipeManager.GetRecipeID(recipe);
            if (recipeID  != -1)
            {
                return recipeID;
            }
            else
            {
                return 0;
            }
            //Leter when the user click the recipe check if the recipeID is not equal to 0
        }

        public static string FormatNumber(int num)
        {
            if (num >= 1000000)
                return (num / 1000000D).ToString("0.#") + "M";
            if (num >= 1000)
                return (num / 1000D).ToString("0.#") + "K";

            return num.ToString();
        }

        private List<Recipe> GetSortedRecipes(string sortOrder, int pageNumber, int pageSize)
        {
            switch (sortOrder)
            {
                case "alphabet":
                    return recipeManager.GetRecipesAlphabetically(pageNumber, pageSize);
                case "newest":
                    return recipeManager.GetRecipesByNewest(pageNumber, pageSize);
                case "oldest":
                    return recipeManager.GetRecipesByOldest(pageNumber, pageSize);
                case "topRated":
                    return recipeManager.GetRecipesByRating(pageNumber, pageSize);
                case "topSaved":
                    return recipeManager.GetRecipesBySaves(pageNumber, pageSize);
                case "recommended":
                        return recommendedRecipesAlgoritam.Recommend(_user);
                default:
                    return  recipeManager.GetAllRecipes(pageNumber, pageSize);
            }
        }

        public async Task<IActionResult> OnPostSearchRecipe(string searchText)
        {
            CurrentPage = 1;
            SearchText = searchText;
            try
            {
                //// Assuming the method SearchRecipesByName is implemented in your IRecipeManager
                Recipes = recipeManager.SearchRecipesByName(searchText, CurrentPage, PageSize);
                TotalPages = recipeManager.GetAllRecipesPageNum(PageSize);
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("", "Failed to load search results. Please try again.");
            }

            PopulateRecipeInteractionData(); // Update other UI elements based on new data
            return Page();
        }

    }
}
