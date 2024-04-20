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
        List<Recipe> Recommend(User user);
    }
}
