using System.Globalization;
using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using CookUp_Companion_BusinessLogic.Managers;
using CookUp_Companion_BusinessLogic.InterfacesLL;

namespace CookUp_Companion_web.Pages
{
    [Authorize]
    public class PlannerModel : PageModel
    {
        public List<Recipe> Recipes;
        public List<int> Likes { get; set; }
        public List<int> Dislikes { get; set; }
        public List<int> SaveCounts { get; set; }

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        [BindProperty]
        public string StartDate { get;  set; }
        [BindProperty]
        public string EndDate { get;  set; }
        public const int PageSize = 24;

        private readonly IRecipeManager recipeManager;
        private readonly IUserManager userManager;
        private readonly IPlannerManager plannerManager;
        private readonly IShoppingCartManager shoppingCartManager;

        public User _user { get; private set; }
        private int userId;

        public int CurrentRecipeId { get; set; }
        [BindProperty]
        public List<Ingredient> SelectedRecipeIngredients { get; set; }

        public Dictionary<string, List<Recipe>> WeeklyPlan { get; set; }

        public PlannerModel(IUserManager userManager, IRecipeManager recipeManager, IPlannerManager plannerManager,IShoppingCartManager shoppingCartManager)
        {
            this.userManager = userManager;
            this.recipeManager = recipeManager;
            this.plannerManager = plannerManager;
            this.shoppingCartManager = shoppingCartManager;
        }
        public void OnGet(int? pageNum, string startDate, string endDate)
        {
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                StartDate = startDate;
                EndDate = endDate;
            }
            else
            {
                SetCurrentWeek(); // Sets to current week if no dates are specified
            }


            CurrentPage = pageNum ?? 1;
            GetSavedRecipes(CurrentPage);
            TotalPages = recipeManager.GetAllRecipesPageNum(PageSize);
            SelectedRecipeIngredients = new List<Ingredient>();


            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);


            }
            if (_user != null)
            {
                userId = userManager.GetIdByUsername(_user.Username); // Implement this in your UserManager to get the current user's ID


                foreach (var recipe in Recipes)
                {
                    int recipeID = recipeManager.GetRecipeID(recipe);

                    
                }

                DateTime startDateTime;
                DateTime endDateTime;
                StartDate= startDate; EndDate= endDate;
                if (startDate != null && endDate != null)
                {
                    startDateTime =  DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    endDateTime =  DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    // If parsing is successful, use the parsed dates
                    WeeklyPlan = plannerManager.GetWeeklyPlan(userId, startDateTime, endDateTime);
                }
                else
                {
                    LoadWeeklyPlan();
                }
            }
            else
            {
                RedirectToPage("/Login");
            }


        }

        public void GetSavedRecipes(int page)
        {
            try
            {
                // Retrieve the authenticated user's claims
                var userClaims = HttpContext.User.Claims;

                var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

                if (userEmailClaim != null)
                {
                    _user = userManager.GetUserByEmail(userEmailClaim.Value);
                    userId = userManager.GetIdByUsername(_user.Username);

                }
                Recipes = recipeManager.GetSavedRecipes(CurrentPage, PageSize, userId);
                TotalPages = recipeManager.GetAllRecipesPageNum(PageSize);
            }
            catch (Exception ex)
            {

                // Add a model error that you can display in the view
                ModelState.AddModelError("", $"Failed to load  saved recipes: {ex.Message}");
                return;
            }


        }

        public int GetRecipeID(Recipe recipe)
        {
            int recipeID = recipeManager.GetRecipeID(recipe);
            if (recipeID != -1)
            {
                return recipeID;
            }
            else
            {
                return 0;
            }
            //Leter when the user click the recipe check if the recipeID is not equal to 0
        }

        public async Task<IActionResult> OnPostSaveWeeklyPlan()
        {
            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);


            }

            userId = userManager.GetIdByUsername(_user.Username); // Implement this in your UserManager to get the current user's ID

                Dictionary<string, List<int>> weeklyPlan = new Dictionary<string, List<int>>();

            // Use the keys from the form to populate the weeklyPlan dictionary
            foreach (var key in Request.Form.Keys.Where(k => k.StartsWith("recipePlans[")))
            {
                // Extract the dayId from the key
                string dayId = key.Split('[', ']')[1];
                List<int> recipeIds = Request.Form[key].Select(int.Parse).ToList();

                weeklyPlan[dayId] = recipeIds;
            }

            bool addSuccess = plannerManager.AddWeeklyPlan(userId, weeklyPlan);


            if (addSuccess)
            {
                TempData["SuccessMessage"] = "Weekly plan saved successfully!";
                TempData["IsAddRecipeSuccess"] = true;
            }
            else
            {
                TempData["ErrorMessage"] = "There was an error saving your weekly plan.";
                TempData["IsAddRecipeSuccess"] = false;
            }

            LoadWeeklyPlan();

            return RedirectToPage();
        }

        private void LoadWeeklyPlan()
        {
            // Get today's date
            DateTime today = DateTime.Today;

            // Calculate how many days to subtract to get to Monday (assuming Monday as the first day of the week)
            int daysToSubtract = (int)today.DayOfWeek - (int)DayOfWeek.Monday;
            if (daysToSubtract < 0)
            {
                // This means today is Sunday, which in the default culture has a DayOfWeek value of 0
                daysToSubtract += 7; // Adjust to go back to the previous Monday
            }

            // Get the start of the week
            DateTime startWeek = today.AddDays(-daysToSubtract);
            DateTime endWeek = startWeek.AddDays(6); ;

            // Convert to string in the format "year-month-day"
            string formattedStarDate = startWeek.ToString("yyyy-MM-dd");
            string formattedEndDate = startWeek.ToString("yyyy-MM-dd");
            StartDate = formattedStarDate;
            EndDate = formattedEndDate;

            // Define the start of the week (Monday) and the end of the week (Sunday)
            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            var endOfWeek = startOfWeek.AddDays(6);
            //StartDate = startOfWeek; EndDate = startOfWeek;

            WeeklyPlan = plannerManager.GetWeeklyPlan(userId, startOfWeek, endOfWeek);
        }

        private void SetCurrentWeek()
        {
            DateTime today = DateTime.Today;
            int daysToSubtract = (int)today.DayOfWeek - (int)DayOfWeek.Monday;
            daysToSubtract = daysToSubtract < 0 ? daysToSubtract + 7 : daysToSubtract;
            DateTime startOfWeek = today.AddDays(-daysToSubtract);
            StartDate = startOfWeek.ToString("yyyy-MM-dd");
            EndDate = startOfWeek.AddDays(6).ToString("yyyy-MM-dd");
        }


        public async Task<IActionResult> OnPostIngredientsForTheRecipeIDAsync()
        {
            int currentRecipeId = int.Parse(Request.Form["CurrentRecipeId"]);
            CurrentRecipeId = currentRecipeId;
            // Fetch ingredients or perform action using the recipeId
            List<Ingredient> ingredients = recipeManager.GetAllIngredientsForRecipeId(CurrentRecipeId);
            SelectedRecipeIngredients = ingredients;
            return Partial("_RecipeIngredientsPartial", this);
        }

        public async Task<IActionResult> OnPostSaveSelectedIngredientsAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Login");
            }

            var userClaims = HttpContext.User.Claims;
            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            _user = userManager.GetUserByEmail(userEmailClaim.Value);
            int userId = userManager.GetIdByUsername(_user.Username);

            int userCartId = shoppingCartManager.GetCartIdByUserId(userId);
            if (userCartId == -1)
            {
                bool isCartCreated = shoppingCartManager.CreateCart(userId);
                if (isCartCreated)
                {
                    userCartId = shoppingCartManager.GetCartIdByUserId(userId); // Attempt to get the new cart ID
                    if (userCartId == -1)
                    {
                        TempData["IsError"] = true;
                        TempData["ErrorMessage"] = "Failed to create a new cart.";
                        return RedirectToPage(); // Redirect with an error message
                    }
                }
                else
                {
                    TempData["IsError"] = true;
                    TempData["ErrorMessage"] = "Failed to create a new cart.";
                    return RedirectToPage(); // Redirect with an error message
                }
            }



            foreach (Ingredient ingredient in SelectedRecipeIngredients)
            {
                // Your logic to save each ingredient
                int ingredientID = recipeManager.GetIngredientIdByName(ingredient.IngredientName);
                bool IsAdded = shoppingCartManager.AddIngredientToCart(userCartId, ingredientID, ingredient.Quantity, ingredient.SelectedUnit);
                if (!IsAdded)
                {
                    TempData["IsError"] = true;
                    TempData["ErrorMessage"] = $"Failed to save the {ingredient.IngredientName} in the cart.";
                }
            }
            TempData["IsSuccess"] = true;
            TempData["SuccessMessage"] = "Ingredients added to the shopping cart successfully!";
            return RedirectToPage();
        }

    }
}
