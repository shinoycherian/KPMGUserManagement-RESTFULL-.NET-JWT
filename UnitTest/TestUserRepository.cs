using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using KPMG.UserManagement.Models;
using KPMG.UserManagement.DataAccessObjects;
using System.Collections.ObjectModel;
using KPMG.UserManagement.Application.Security.Tokens;
namespace KPMG.UserManagement.Test.UnitTest
{
    [TestClass]
    public class TestUserRepository
    {
        [TestMethod]
        public void TestCreateUser()
        {
            User user = CreateUser();

            UserRepository repository = RepositoryHelper.GetUserRepository();
            repository.Add(user);
            repository.Save();
            IEnumerable<User> userlist = repository.Repository.Find(p => p.UserName == user.UserName);
            Assert.IsNotNull(userlist);
           
        }
        [TestMethod]
        public void TestCreateRole()
        {
            Role role = new Role { Id = 1, Name = "Administrator" };

            RoleRepository repository = RepositoryHelper.GetRoleRepository();
            repository.Add(role);
            repository.Save();
            IEnumerable<Role> rolelist = repository.Repository.Find(p => p.Id ==1);
            Assert.IsNotNull(rolelist);

        }


        public User CreateUser()
        {
            var user = new User()
            {
                FirstName = "Firstname5",
                LastName = "Lastname5",
                UserName= "Firstname5.Lastname5",
                PasswordHash = "aerzcafecd<"
            };

            return user;
        }
        
    }
}
