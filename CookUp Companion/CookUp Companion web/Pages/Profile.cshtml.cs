using CookUp_Companion_BusinessLogic.Manager;
using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CookUp_Companion_web.Pages
{
    [Authorize] // Restricts access to authenticated users only
    public class ProfileModel : PageModel
    {
        private readonly ILogger<ProfileModel> _logger;
        private User user;

        private readonly IRecipeManager recipeManager;
        private readonly IUserManager userManager;
        public ProfileModel(IUserManager userManager, IRecipeManager recipeManager)
        {
            this.userManager = userManager;
            this.recipeManager = recipeManager;
        }

        public IFormFile? userProfilePicture { get; set; }
        public byte[] UserProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; private set; }
        public string Username { get; private set; }
        public string Role { get; private set; }
        public User _user  { get; private set; }

        public List<Recipe> LikedRecipes;
        public List<Recipe> CreatedRecipes;
        public List<bool> IsFavorite;
        public List<int> LikedLikes { get; set; }
        public List<int> LikedDislikes { get; set; }
        public List<int> LikedSaveCounts { get; set; }
        public List<int> CreatedLikes { get; set; }
        public List<int> CreatedDislikes { get; set; }
        public List<int> CreatedSaveCounts { get; set; }
        public int CurrentPageActivity { get; set; }
        public int TotalPagesActivity { get; set; }
        public int CurrentPageCreated { get; set; }
        public int TotalPagesCreated { get; set; }
        public string SearchText { get; set; }
        public const int PageSize = 4;

        public int userId {  get; set; }
        public string ActiveTab { get; set; }

        public void OnGet(int? pageNumActivity, int? pageNumCreated, string tab = "activity")
        {
            ActiveTab = tab;
            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);


            }
            userId = userManager.GetIdByUsername(_user.Username);
            if (_user != null)
            {
                UserProfilePicture = _user.ProfilePicture;
                FirstName = _user.FirstName;
                LastName = _user.LastName;
                Username = _user.Username;
            }

            if (tab == "created")
            {
                CurrentPageCreated = pageNumCreated ?? 1;
                CreatedRecipes = recipeManager.GetRecipesCreatedByUser(CurrentPageCreated, PageSize, userId);
                TotalPagesCreated = recipeManager.GetAllRecipesPageNum(PageSize);
                CreatedRecipeInfo();
                
            }
            else
            {
                CurrentPageActivity = pageNumActivity ?? 1;
                LikedRecipes = recipeManager.GetLikedRecipes(CurrentPageActivity, PageSize, userId);
                TotalPagesActivity = recipeManager.GetAllRecipesPageNum(PageSize);
                LikedRecipeInfo();
            }

            
        }

        public void LikedRecipeInfo()
        {
            TotalPagesActivity = recipeManager.GetAllRecipesPageNum(PageSize);
            IsFavorite = new List<bool>();
            LikedLikes = new List<int>();
            LikedDislikes = new List<int>();
            LikedSaveCounts = new List<int>();

            foreach (var recipe in LikedRecipes)
            {
                int recipeID = recipeManager.GetRecipeID(recipe);

                var (likes, dislikes) = recipeManager.GetLikesAndDislikes(recipeID);
                LikedLikes.Add(likes);
                LikedDislikes.Add(dislikes);
                IsFavorite.Add(recipeManager.CheckIfFavorite(userId, recipeID));
                LikedSaveCounts.Add(recipeManager.GetSaveCount(recipeID));
            }
            
        }

        public void CreatedRecipeInfo()
        {
            TotalPagesCreated = recipeManager.GetAllRecipesPageNum(PageSize);
            CreatedLikes = new List<int>();
            CreatedDislikes = new List<int>();
            CreatedSaveCounts = new List<int>();

            foreach (var recipe in CreatedRecipes)
            {
                int recipeID = recipeManager.GetRecipeID(recipe);

                var (likes, dislikes) = recipeManager.GetLikesAndDislikes(recipeID);
                CreatedLikes.Add(likes);
                CreatedDislikes.Add(dislikes);

                CreatedSaveCounts.Add(recipeManager.GetSaveCount(recipeID));
            }

        }

        public async Task<IActionResult> OnPostChangeUserProfile(IFormFile userProfilePicture, string FirstName, string LastName, string Username)
        {
            // Retrieve the authenticated user's current profile data
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            _user = userManager.GetUserByEmail(userEmail);

            if (_user == null)
            {
                ModelState.AddModelError("error", "User not found.");
                return Page();
            }
            bool isUpdated = false;

            if (userProfilePicture != null && userProfilePicture.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await userProfilePicture.CopyToAsync(memoryStream);
                    // Set the new profile picture if it's different
                    if (!memoryStream.ToArray().SequenceEqual(_user.ProfilePicture))
                    {
                        _user.ChangeProfilePicture(memoryStream.ToArray());
                        //_user.ProfilePicture = memoryStream.ToArray();
                        isUpdated = true;
                    }
                }
            }
            if (!string.Equals(FirstName, _user.FirstName))
            {
                _user.ChangeFirstName(FirstName);
                isUpdated = true;
            }
            if (!string.Equals(LastName, _user.LastName))
            {
                _user.ChangeLastName(LastName);
                isUpdated = true;
            }
            if (!string.Equals(Username, _user.Username))
            {
                _user.ChangeUsername(Username);
                isUpdated = true;
            }

            if (isUpdated)
            {
               bool result =  userManager.UpdateUser(_user);

                if (result)
                {
                    TempData["SuccessMessage"] = "Profile updated successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to update profile.";
                    return Page();
                }
            }
            else
            {
                TempData["InfoMessage"] = "No changes detected";
            }

             return Redirect("/Profile");
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

        public void OnPostSwitchTab(string selectedTab, int? pageNumActivity, int? pageNumCreated)
        {
            ActiveTab = selectedTab; // Set the active tab based on the form submission

            OnGet(pageNumActivity, pageNumCreated, selectedTab);
        }

    }
}
