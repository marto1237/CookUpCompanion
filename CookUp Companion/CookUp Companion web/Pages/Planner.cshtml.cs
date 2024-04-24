
using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

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
        public const int PageSize = 24;

        private readonly IRecipeManager recipeManager;
        private readonly IUserManager userManager;
        private readonly IPlannerManager plannerManager;

        public User _user { get; private set; }
        private int userId;

        public Dictionary<string, List<Recipe>> WeeklyPlan { get; set; }

        public PlannerModel(IUserManager userManager, IRecipeManager recipeManager, IPlannerManager plannerManager)
        {
            this.userManager = userManager;
            this.recipeManager = recipeManager;
            this.plannerManager = plannerManager;
        }
        public void OnGet(int? pageNum, string startDate, string endDate)
        {
            CurrentPage = pageNum ?? 1;
            
            GetIngredients(CurrentPage);
            TotalPages = recipeManager.GetAllRecipesPageNum(PageSize);

           

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

                if (DateTime.TryParse(startDate, out startDateTime) && DateTime.TryParse(endDate, out endDateTime))
                {
                    // If parsing is successful, use the parsed dates
                    WeeklyPlan = plannerManager.GetWeeklyPlan(userId, startDateTime, endDateTime);
                }
                else
                {
                    // If parsing fails, default to current week or handle the error
                    var today = DateTime.Today;
                    var startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
                    var endOfWeek = startOfWeek.AddDays(6);
                    WeeklyPlan = plannerManager.GetWeeklyPlan(userId, startOfWeek, endOfWeek);
                }
            }
            else
            {
                RedirectToPage("/Login");
            }


        }

        public void GetIngredients(int page)
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

        //public async Task<IActionResult> OnPostSaveRecipeDay(int recipeId, string day)
        //{
        //    var result = true;
        //    //var userId = _userManager.GetUserId(User); // Ensure you have a method to retrieve the currently logged-in user's ID

        //    //// Assume you have a method to save the data
        //    //var result = await _context.SaveRecipeDayAsync(recipeId, day, userId);
        //    if (result)
        //    {
        //        TempData["SuccessMessage"] = "Recipe successfully added to the day!";
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = "Failed to add recipe.";
        //    }

        //    return RedirectToPage(); // Optionally redirect back to the same page or another confirmation page
        //}
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
            // Define the start of the week (Monday) and the end of the week (Sunday)
            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            var endOfWeek = startOfWeek.AddDays(6);

            WeeklyPlan = plannerManager.GetWeeklyPlan(userId, startOfWeek, endOfWeek);
        }



    }
}
