using CookUp_Companion_BusinessLogic.Manager;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockClasses;

namespace UnitTests.Tests
{
    public class PlannerTest
    {
        private PlannerManager plannerManager;
        private FakePlannerDal fakeDal;

        [Fact]
        public void AddWeeklyPlan_Successful()
        {
            // Arrange
            fakeDal = new FakePlannerDal();
            plannerManager = new PlannerManager(fakeDal);
            int userId = 1;
            var weeklyPlan = new Dictionary<string, List<int>>
            {
                { "Monday", new List<int> { 1, 2 } },
                { "Tuesday", new List<int> { 2 } }
            };

            // Act
            bool result = fakeDal.AddWeeklyPlan(userId, weeklyPlan);

            // Assert
            Assert.True(result);
            Assert.True(fakeDal.GetWeeklyPlan(userId, DateTime.Today, DateTime.Today.AddDays(7)).Count > 0);
        }

        [Fact]
        public void AddWeeklyPlan_Unsuccessful()
        {
            // Arrange
            fakeDal = new FakePlannerDal();
            plannerManager = new PlannerManager(fakeDal);
            int userId = 99; // User ID that does not exist
            var weeklyPlan = new Dictionary<string, List<int>>
            {
                { "Monday", new List<int> { 1, 2 } },
                { "Tuesday", new List<int> { 2 } }
            };

            // Act
            bool result = fakeDal.AddWeeklyPlan(userId, weeklyPlan);

            // Assert
            Assert.False(result);
        }


    }
}
