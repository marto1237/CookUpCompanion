using CookUp_Companion_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CelendarControl
    {
        public WeeklyCalendar WeeklyPlan { get; private set; }

        public CelendarControl(User user) 
        {
            WeeklyCalendar WeeklyPlan = new WeeklyCalendar(user);
        }

        public void CreateWeeklyPlan(User user)
        {
            WeeklyPlan = new WeeklyCalendar(user);  
        }
        public void AssignRecipe(WeeklyCalendar weeklyCalendar, User user,DateTime dayOfWeek, Recipe recipe) 
        {
            if(weeklyCalendar.User == user)
            {
                weeklyCalendar.AssignMealForDayOfTheWeek(dayOfWeek, recipe);
            }

            
        }

        public void RemoveRecipe(User user, Recipe recipe, DayOfWeek dayOfWeek)
        {
            if(WeeklyPlan.User == user) 
            {
                WeeklyPlan.RemoveMealFromThePlaner(dayOfWeek, recipe);

            }

        }
        public WeeklyCalendar GetWeeklyPlan(User user)
        {
            if (WeeklyPlan.User == user) 
            {
                return WeeklyPlan;
            }
            else
            {
                return new WeeklyCalendar(user);
            }
        }

        
    }
}
