using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion_BusinessLogic.InterfacesLL
{
    public interface IRecommendedRecipesAlgoritam
    {
        List<Recipe> Recommend(User user, int pageNumber, int pageSize);
        List<Recipe> GetUserLikedRecipes(int userId);
        List<Recipe> RecommendTrendingRecipes(int pageNumber, int pageSize);
        bool IsRecipeSimilar(Recipe one, Recipe two);
        double CalculateTrendScore(Recipe recipe, DateTime referenceDate);
        List<Recipe> CombineRecipesForTrends(int pageNumber, int pageSize);
        DateTime GetRecipeCreateDate(int recipeId);
        (int Likes, int Dislikes) GetRecipeLikesAndDislikes(int recipeId);
        int GetRecipeSaveCount(int recipeId);
        int GetRecipeId(Recipe recipe);
    }
}
