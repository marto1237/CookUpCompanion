
using CookUp_Companion_BusinessLogic.InterfacesLL;
using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion_BusinessLogic.Manager
{
    public class PlannerManager : IPlannerManager
    {
        IPlannerDALManager plannerDAL;

        public PlannerManager(IPlannerDALManager plannerDAL)
        {
            this.plannerDAL = plannerDAL;
        }

        public bool AddWeeklyPlan(int userId, Dictionary<string, List<int>> weeklyPlan) { return plannerDAL.AddWeeklyPlan(userId, weeklyPlan); }
        public Dictionary<string, List<Recipe>> GetWeeklyPlan(int userId, DateTime startOfWeek, DateTime endOfWeek) { return plannerDAL.GetWeeklyPlan(userId, startOfWeek, endOfWeek); }
    }
}
