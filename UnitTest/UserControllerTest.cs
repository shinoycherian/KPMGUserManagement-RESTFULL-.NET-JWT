using Moq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KPMG.UserManagement.Controllers.User;
using KPMG.UserManagement.Models;
using KPMG.UserManagement.Application.Services;
using KPMG.UserManagement.BusinessObjects;
using KPMG.UserManagement.Application.Authorization;
using KPMG.UserManagement.Application.ApiModels.User;
using KPMG.UserManagement.Application.Security;
using KPMG.UserManagement.Application.Security.Tokens;
namespace KPMG.UserManagement.Test.UnitTest
{

    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Createuser()
        {
            
             RegisterUserApiRequest registerusermodel = RegisterUserModel();         
            var mockUserBusinessObject = new Mock<IUserBusinessObject>();
            var mockMapper = new Mock<IMapper>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterUserApiRequest, User>();
            });
            var mapper = config.CreateMapper();
            var mockhashObject = new Mock<IPasswordHasher>();
            var mockJwtTokenObject = new Mock<ITokenHandler>();
            var userService = new UserService(mockMapper.Object, mockUserBusinessObject.Object
                , mockhashObject.Object, mockJwtTokenObject.Object);
            UserController usercontroller = new UserController(userService);
                     
            var result= usercontroller.Register(registerusermodel);
            Assert.IsNotNull(result);

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
       
    }
}
