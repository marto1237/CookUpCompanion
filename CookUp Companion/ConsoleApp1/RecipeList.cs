using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class RecipeList
    {
        [JsonProperty("results")]
        public IEnumerable<Recipe> Recipes { get; set; }
    }
}
