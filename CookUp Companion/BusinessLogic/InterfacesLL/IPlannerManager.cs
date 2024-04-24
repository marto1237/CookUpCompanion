using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface IPlannerManager
    {
        bool AddWeeklyPlan(int userId, Dictionary<string, List<int>> weeklyPlan);
        Dictionary<string, List<Recipe>> GetWeeklyPlan(int userId, DateTime startOfWeek, DateTime endOfWeek);
    }
}
