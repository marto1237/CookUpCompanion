using CookUp_Companion_BusinessLogic.InterfacesLL;
using CookUp_Companion_BusinessLogic.Manager;
using CookUp_Companion_BusinessLogic.Managers;
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
    public class ShoppingCartTest
    {
        private ShoppingCartManager shoppingCartManager;
        private UserManager userManager;
        private FakeUserDALManager fakeUserDAL;
        private FakeShoppingCartDal fakeDal;

        [Fact]
        public void AddIngredientToCart_AddsIngredient_Successfully()
        {
            // Arrange
            fakeDal = new FakeShoppingCartDal();
            fakeUserDAL = new FakeUserDALManager();
            userManager = new UserManager(fakeUserDAL);
            shoppingCartManager = new ShoppingCartManager(fakeDal, userManager);
            int userId = 1;
            fakeDal.CreateCart(userId);

            // Act
            bool result = fakeDal.AddIngredientToCart(userId, 101, 2.5f, "kg");

            // Assert
            Assert.True(result);
            List<Ingredient> ingredients = fakeDal.GetShoppingCartIngredients(userId);
            Assert.Single(ingredients);
            Assert.Contains(ingredients, i => i.IngredientId == 101 && i.Quantity == 2.5f && i.SelectedUnit == "kg");
        }

        [Fact]
        public void AddIngredientToCart_Fails_WhenCartDoesNotExist()
        {
            // Arrange
            fakeDal = new FakeShoppingCartDal();
            fakeUserDAL = new FakeUserDALManager();
            userManager = new UserManager(fakeUserDAL);
            shoppingCartManager = new ShoppingCartManager(fakeDal, userManager);

            // Act
            bool result = fakeDal.AddIngredientToCart(999, 101, 1.5f, "kg"); // Cart ID 999 does not exist

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CreateCart_ShouldCreateCartIfNotExists()
        {
            // Arrange
            fakeDal = new FakeShoppingCartDal();
            fakeUserDAL = new FakeUserDALManager();
            userManager = new UserManager(fakeUserDAL);
            shoppingCartManager = new ShoppingCartManager(fakeDal,userManager);

            //Act
            bool result = fakeDal.CreateCart(1); 

            // Assert
            Assert.True(result);
            Assert.Empty(fakeDal.GetShoppingCartIngredients(3));
        }
        [Fact]
        public void CreateCart_ShouldFailIfCartAlreadyExists()
        {
            // Arrange
            fakeDal = new FakeShoppingCartDal();
            fakeUserDAL = new FakeUserDALManager();
            userManager = new UserManager(fakeUserDAL);
            shoppingCartManager = new ShoppingCartManager(fakeDal,userManager);

            //Act
            fakeDal.CreateCart(1);
            bool result = fakeDal.CreateCart(1);

            
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetShoppingCartIngredients_ReturnsIngredients()
        {
            // Arrange
            fakeDal = new FakeShoppingCartDal();
            fakeUserDAL = new FakeUserDALManager();
            userManager = new UserManager(fakeUserDAL);
            shoppingCartManager = new ShoppingCartManager(fakeDal, userManager);
            int userId = 1;
            fakeDal.CreateCart(userId);
            fakeDal.AddIngredientToCart(userId, 101, 1.5f, "kg");

            // Act
            var ingredients = fakeDal.GetShoppingCartIngredients(userId);

            // Assert
            Assert.Single(ingredients);
            Assert.Contains(ingredients, i => i.IngredientId == 101);
        }

        [Fact]
        public void GetShoppingCartIngredients_ReturnsEmptyListForNewUser()
        {
            // Arrange
            fakeDal = new FakeShoppingCartDal();
            fakeUserDAL = new FakeUserDALManager();
            userManager = new UserManager(fakeUserDAL);
            shoppingCartManager = new ShoppingCartManager(fakeDal, userManager);

            // Act
            var ingredients = fakeDal.GetShoppingCartIngredients(999); // User ID 999 does not exist

            // Assert
            Assert.Empty(ingredients);
        }

        [Fact]
        public void RemoveIngredientToCart_RemoveIngredient_Successfully()
        {
            // Arrange
            fakeDal = new FakeShoppingCartDal();
            fakeUserDAL = new FakeUserDALManager();
            userManager = new UserManager(fakeUserDAL);
            shoppingCartManager = new ShoppingCartManager(fakeDal, userManager);
            int userId = 1;
            fakeDal.CreateCart(userId);

            // Act
            fakeDal.AddIngredientToCart(userId, 101, 2.5f, "kg");
            bool result = fakeDal.RemoveIngredientFromCart(userId, 101, 2.5f, "kg");

            // Assert
            Assert.True(result);
            List<Ingredient> ingredients = fakeDal.GetShoppingCartIngredients(userId);
            Assert.Empty(ingredients);
        }

        [Fact]
        public void RemoveIngredientToCart_Fails_WhenTheIngredientIsNotInTheCart()
        {
            // Arrange
            fakeDal = new FakeShoppingCartDal();
            fakeUserDAL = new FakeUserDALManager();
            userManager = new UserManager(fakeUserDAL);
            shoppingCartManager = new ShoppingCartManager(fakeDal, userManager);
            int userId = 1;
            fakeDal.CreateCart(userId);

            // Act
            fakeDal.AddIngredientToCart(userId, 101, 2.5f, "kg");
            bool result = fakeDal.RemoveIngredientFromCart(userId, 999, 2.5f, "kg"); //No ingredient with ID 999 in the cart

            // Assert
            Assert.False(result);
            List<Ingredient> ingredients = fakeDal.GetShoppingCartIngredients(userId);
            Assert.Single(ingredients);
            Assert.DoesNotContain(ingredients, i => i.IngredientId == 999);
        }

    }
}
