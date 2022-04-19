

namespace KPMG.UserManagement.Test.UnitTest
{
    using Moq;
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KPMG.UserManagement.Models;
    using KPMG.UserManagement.Application.Services;
    using KPMG.UserManagement.Application.Authorization;
    using KPMG.UserManagement.Application.ApiModels.User;
    using KPMG.UserManagement.Application.Security;
    using KPMG.UserManagement.Application.Security.Tokens;
    using KPMG.UserManagement.BusinessObjects;
    using System.Collections.ObjectModel;

    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void GetAllUsersTest()
        {
            // arrange
            var mockUserBusinessObject = new Mock<IUserBusinessObject>();
            var mockMapper = new Mock<IMapper>();            // act
            var mockhashObject = new Mock<IPasswordHasher>();
            var mockJwtTokenObject = new Mock<ITokenHandler>();
            var UserService = new UserService(mockMapper.Object,mockUserBusinessObject.Object
                ,mockhashObject.Object, mockJwtTokenObject.Object);
            var result = UserService.GetAllUsers();
            Assert.IsNotNull(result);
           
        }

        [TestMethod]
        public void RegisterUserTest()
        {
            
            RegisterUserApiRequest user = RegisterUserModel();         
            var mockUserBusinessObject = new Mock<IUserBusinessObject>();
            var mockMapper = new Mock<IMapper>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterUserApiRequest, User>();
            });
            var mapper = config.CreateMapper();
            var mockhashObject = new Mock<IPasswordHasher>();
            var mockJwtTokenObject = new Mock<ITokenHandler>();
            var UserService = new UserService(mockMapper.Object, mockUserBusinessObject.Object
                , mockhashObject.Object, mockJwtTokenObject.Object);
            RegisterUserApiResponse serviceresult =  UserService.RegisterUser(user);
            Assert.IsNull(serviceresult);

        }
        public RegisterUserApiRequest RegisterUserModel()
        {
            var userapimodel = new RegisterUserApiRequest
            {
                FirstName = "Elon",
                LastName = "Musk",
                UserName = "Elon.Musk"
            };
            return userapimodel;
        }
        public User CreateUser()
        {
            var user = new User()
            {
                FirstName = "Martin",
                LastName = "Fowler",
                PasswordHash = "aerzcafecd<"
            };

            return user;
        }

    }
}
