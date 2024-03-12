using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    [Serializable]
    public class Recipe
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
