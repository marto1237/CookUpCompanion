using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class WeeklyCalendar
    {
        public DateTime WeekStartDay { get; private set; }
        public DateTime WeekEndDay { get; private set;}
        public User User { get; private set; }
        public  List<Recipe> SavedRecipes { get; private set; } 
        public Dictionary<DayOfWeek , List<Recipe>> DailyRecipes { get; private set; }

        public WeeklyCalendar(User user)
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Calculate the number of days to subtract to get to the start of the week (Monday)
            int daysToSubtract = ((int)currentDate.DayOfWeek - (int)DayOfWeek.Monday +7) % 7;

            // Calculate the start of the current week by subtracting daysToSubtract from the current date
            WeekStartDay = currentDate.AddDays(-daysToSubtract);

            // Calculate the end of the week by adding 6 days to the start
            WeekEndDay = WeekStartDay.AddDays(6);

            User = user;

            SavedRecipes = user.Preferences.SavedRecipes;

            DailyRecipes = new Dictionary<DayOfWeek , List<Recipe>>();


        }

        public List<Recipe> GetSavedRecipes(User user)
        {
            return SavedRecipes;
        }

        public DateTime GetWeekStartDay()
        {
            return WeekStartDay;
        }

        public DateTime GetWeekEndDay() 
        { 
            return WeekEndDay; 
        }
        public void AssignMealForDayOfTheWeek(DateTime day, Recipe recipe)
        {
            if (CheckForNewWeek())
            {
                //it will create the weekly calendar
            }
            else
            {
                if (DailyRecipes.ContainsKey(day.DayOfWeek))
                {
                    DailyRecipes[day.DayOfWeek].Add(recipe);
                }
                else
                {
                    DailyRecipes.Add(day.DayOfWeek, new List<Recipe> { recipe });
                }   
            }

        }

        public void RemoveMealFromThePlaner(DayOfWeek dayOfWeek, Recipe recipe)
        { 
            if (DailyRecipes.ContainsKey(dayOfWeek))
            {
                var recipeList = DailyRecipes[dayOfWeek];
                if (recipeList.Contains(recipe))
                {
                    DailyRecipes[dayOfWeek].Remove(recipe); 
                }
                
            }
        }

        public bool CheckForNewWeek()
        {
            // Check if the current date is beyond the end of the current week
            if (DateTime.Now > WeekEndDay)
            {
                // If so, initialize a new week
                WeeklyCalendar newWeek = new WeeklyCalendar(User);
                this.WeekStartDay = newWeek.WeekStartDay;
                this.WeekEndDay = newWeek.WeekEndDay;
                this.DailyRecipes = newWeek.DailyRecipes;
            }
            return true;
        }
    }
}
