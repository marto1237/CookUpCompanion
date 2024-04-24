using CookUp_Companion_BusinessLogic.Manager;
using InterfaceDAL;
using Logic;
using System;
using Xunit;
using UnitTests.MockClasses;
using System.Runtime.Intrinsics.X86;

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
            CreateUser("checkExistingUser", "checkExisting@example.com", "password1234", "checkExisting", "User2", 2);
            CreateUser("bannedUser", "banned@example.com", "password123", "Banned", "User", 2);
            CreateUser("bannedUser", "banned@example.com", "password123", "Banned", "User", 2);
            CreateUser("admin", "admin@example.com", "adminPass123", "Admin", "User", 3); 
            CreateUser("userToBan", "userToBan@example.com", "userPass123", "ToBan", "User", 1);
        }
        [Fact]
        public void GetAll_ShouldReturnAllUsers_WhenThereIsNotUser()
        {
            // Act
            var result = userManager.GetAllUsers();

            // Assert
            Assert.True(result.Count > 0);
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
           
            // Act
            bool doesExist = userManager.CheckExistingUsername("checkExistingUser");

            // Assert
            Assert.True(doesExist);
        }

        [Fact]
        public void CheckExistingUsername_ShouldReturnFalse_WhenUsernameDoesNotExist()
        {

            // Act
            bool doesNotExist = userManager.CheckExistingUsername("nonExistentUser");

            // Assert
            Assert.False(doesNotExist);
        }

        [Fact]
        public void CheckExistingEmail_ShouldReturnTrue_WhenUsernameExists()
        {

            // Act
            bool doesExist = userManager.CheckExistingEmail("checkExisting@example.com");

            // Assert
            Assert.True(doesExist);
        }


        [Fact]
        public void CheckExistingEmail_ShouldReturnFalse_WhenUsernameDoesNotExist()
        {
            // Arrange is already done in the setup

            // Act
            bool doesNotExist = userManager.CheckExistingEmail("nonExistentEmail@gmail.com");

            // Assert
            Assert.False(doesNotExist);
        }

        
        [Fact]
        public void UpdateUserPassword_ShouldReturnTrue_WhenPasswordIsUpdated()
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

        [Fact]
        public void GetAll_ShouldReturnAllUsers_WhenThereIsUser()
        {
            // Act
            var result = userManager.GetAllUsers();

            // Assert
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void GetUserByEmail_ShouldRetrieveCorrectUser()
        {
            // Act
            User user = userManager.GetUserByEmail("logIn@example.com");

            // Assert
            Assert.NotNull(user);
            Assert.Equal("logInUser", user.Username);
        }

        [Fact]
        public void UpdatePassword_ShouldFail_WhenUserDoesNotExist()
        {
            // Arrange
            User nonExistingUser = new User(null, "nonExist", "nonexist@example.com", "hash", "Non", "Exist", 1, null);
            bool insertUser = userManager.CreateUser(nonExistingUser);
            // Act
            bool result = userManager.UpdateUserPassword(nonExistingUser, "newPassword");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void BanUser_ShouldSuccessfullyBanUser()
        {
            // Arrange
            User userToBan = userManager.GetUserByEmail("userToBan@example.com");
            User adminUser = userManager.GetUserByEmail("admin@example.com");

            // Act
            bool banResult = userManager.BanningUser(adminUser, userToBan, "Violation of terms", 1);

            // Assert
            Assert.True(banResult);
            Assert.True(userManager.BannedUser(userToBan));  // This checks if the user is really banned
        }

        [Fact]
        public void BannedUser_ShouldReturnTrue_WhenUserIsBanned()
        {
            // Arrange
            User adminUser = userManager.GetUserByEmail("admin@example.com");
            User userToBan = userManager.GetUserByEmail("userToBan@example.com");

            // Act
            bool banResult = userManager.BanningUser(adminUser, userToBan, "Violation of terms", 1);
            bool isBanned = userManager.BannedUser(userToBan);

            // Assert
            Assert.True(banResult, "User should be successfully banned.");
            Assert.True(isBanned, "User should be marked as banned.");
        }



        [Fact]
        public void BannedUser_ShouldReturnFalse_WhenUserIsNotBanned()
        {
            // Arrange
            var normalUser = userManager.GetUserByEmail("normal@example.com");

            // Act
            bool isBanned = userManager.BannedUser(normalUser);

            // Assert
            Assert.False(isBanned);
        }

        [Fact]
        public void UnbanUser_ShouldUnban_WhenUserIsBanned()
        {
            // Arrange - Assume the user is already banned
            User bannedUser = userManager.GetUserByEmail("userToBan@example.com");
            User banningUser = userManager.GetUserByEmail("admin@example.com");
            bool ban= userManager.BanningUser(banningUser, bannedUser, "Violation", 1);
            int userId = userManager.GetIdByUsername(bannedUser.Username);

            // Act
            bool result = userManager.UnbanningUser(userId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Get_UserRole_WhenUserExist()
        {
            // Arrange - Assume the user is already banned
            User user = userManager.GetUserByEmail("logIn@example.com");

            // Act
            string result = userManager.GetRole(user);

            // Assert
            Assert.NotNull(result);

        }

        [Fact]
        public void Login_Successful_ReturnCurrentUser()
        {
            // Act
            User result = userManager.Login("logIn@example.com", "password1234");

            User current = userManager.CurrentUser();
            // Assert
            Assert.NotNull(current);
        }

        [Fact]
        public void GetUserById_ShouldReturnUser_WhenIdExists()
        {
            User user = userManager.GetUserById(1); 
            Assert.NotNull(user);
        }

        [Fact]
        public void GetUserById_ShouldReturnNull_WhenIdDoesNotExist()
        {
            var user = userManager.GetUserById(-1); 
            Assert.Null(user);
        }

        [Fact]
        public void GetBySearch_ShouldReturnUsers_WhenSearchMatches()
        {
            var users = userManager.GetBySearch("User"); 
            Assert.True(users.Count > 0);
        }

        [Fact]
        public void GetBySearch_ShouldReturnEmpty_WhenNoMatch()
        {
            var users = userManager.GetBySearch("xyz123"); 
            Assert.Empty(users);
        }

        [Fact]
        public void DeleteUser_ShouldReturnTrue_WhenUserExists()
        {
            var result = userManager.DeleteUser(1); 
            Assert.True(result);
        }

        [Fact]
        public void DeleteUser_ShouldReturnFalse_WhenUserDoesNotExist()
        {
            var result = userManager.DeleteUser(-1); 
            Assert.False(result);
        }
        [Fact]
        public void GetBanReason_ShouldReturnReason_WhenUserIsBanned()
        {
            User bannedUser = userManager.GetUserByEmail("userToBan@example.com");
            User banningUser = userManager.GetUserByEmail("admin@example.com");
            bool ban = userManager.BanningUser(banningUser, bannedUser, "Violation", 1);

            int userId = userManager.GetIdByUsername(bannedUser.Username);
            var reason = userManager.GetBanReason(userId);
            Assert.Equal("Violation", reason);
        }

        [Fact]
        public void GetBanReason_ShouldReturnNull_WhenUserIsNotBanned()
        {

            var reason = userManager.GetBanReason(2); 
            Assert.Null(reason);
        }

        [Fact]
        public void GetUsersBySimilarUsernames_WithValidSearch()
        {
            List<User> similarUsernames= userManager.GetUsersBySimilarUsername("user");

            Assert.NotNull(similarUsernames);
        }

        [Fact]
        public void GetUsersBySimilarUsernames_WithInvalidSearch()
        {
            List<User> similarUsernames = userManager.GetUsersBySimilarUsername("notexistingrearch");

            Assert.True(similarUsernames.Count == 0);
        }

        [Fact]
        public void GetUsersBySimilarEmails_WithValidSearch()
        {
            List<User> similarUsernames = userManager.GetUsersBySimilarEmail("user");

            Assert.NotNull(similarUsernames);
        }

        [Fact]
        public void GetUsersBySimilarEmails_WithInvalidSearch()
        {
            List<User> similarEmails = userManager.GetUsersBySimilarEmail("notexistingrearch");

            Assert.True(similarEmails.Count == 0);
        }

        [Fact]

        public void GetAllRoles()
        {
            List<string> roles = userManager.AllRoles();

            Assert.NotNull(roles);
        }

        [Fact]

        public void GetAllBannedUsers()
        {
            List<User> bannedUser = userManager.GetBannedUsers();

            Assert.NotNull(bannedUser);
        }

        [Fact]
        public void GetRoleIdByRoleName_WithValidRoleName()
        {
            int roleId = userManager.GetRoleIdByRoleName("Admin");

            Assert.NotNull(roleId);
        }

        public void GetRoleIdByRoleName_WithNotValidRoleName()
        {
            int roleId = userManager.GetRoleIdByRoleName("FakeRole");

            Assert.Null(roleId);
        }
         
    }
}
