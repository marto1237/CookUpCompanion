using CookUp_Companion_BusinessLogic.Manager;
using InterfaceDAL;
using Logic;
using System;
using Xunit;
using UnitTests.MockClasses;

namespace UnitTests.UserManagerTests
{
    public class UserManagerTest
    {
        private UserManager userManager;
        private FakeUserDALManager fakeDal;

        public UserManagerTest()
        {
            fakeDal = new FakeUserDALManager();
            userManager = new UserManager(fakeDal);
            SetupFakeUsers();
        }

        private void SetupFakeUsers()
        {
            CreateUser("signUpUser", "signUpt@example.com", "password123", "signUp", "User", 1);
            CreateUser("logInUser", "logIn@example.com", "password1234", "logIn", "User", 3);
            CreateUser("checkExistingUser", "checkExisting@example.com", "password1234", "checkExisting", "User2", 2);
        }

        private void CreateUser(string username, string email, string password, string firstName, string lastName, int roleId)
        {
            byte[] salt = userManager.GenerateSalt();
            string hashedPassword = userManager.HashPassword(password, salt, 10000);
            var user = new User(null, username, email, hashedPassword, firstName, lastName, roleId, null);
            user.ChangePasswordSalt(Convert.ToBase64String(salt));
            fakeDal.InsertUser(user);
        }

        [Fact]
        public void InsertUser_ShouldReturnTrue_WhenUserIsCreatedSuccessfully()
        {
            // Act
            var result = userManager.CreateUser(new User(null, "newUser", "new@example.com", "newPassword", "FirstName", "LastName", 1, null));

            // Assert
            Assert.True(result);
            Assert.NotNull(fakeDal.GetUserByEmail("new@example.com"));
        }



        [Fact]
        public void Login_Successful_ReturnsUser()
        {
            // Act
            User result = userManager.Login("logIn@example.com", "password1234");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("logInUser", result.Username);
        }
        [Fact]
        public void Login_Failed_WithIncorrectPassword()
        {
            // Act
            User result = userManager.Login("logIn@example.com", "wrongPassword");

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public void CheckExistingUsername_ShouldReturnTrue_WhenUsernameExists()
        {
            // Arrange is already done in the setup

            // Act
            bool doesExist = userManager.CheckExistingUsername("checkExistingUser");

            // Assert
            Assert.True(doesExist);
        }
        

        [Fact]
        public void CheckExistingUsername_ShouldReturnFalse_WhenUsernameDoesNotExist()
        {
            // Arrange is already done in the setup

            // Act
            bool doesNotExist = userManager.CheckExistingUsername("nonExistentUser");
            
            // Assert
            Assert.False(doesNotExist);
        }

        [Fact]
        public void UpdatePassword_Successful()
        {
            // Arrange
            string newPassword = "newSecurePassword123";
            User userToUpdate = userManager.GetUserByEmail("logIn@example.com");

            // Act
            bool updateResult = userManager.UpdateUserPassword(userToUpdate, newPassword);
            User result = userManager.Login("logIn@example.com", newPassword);

            // Assert
            Assert.True(updateResult);
            Assert.NotNull(result);
        }
    }
}
