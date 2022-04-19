using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPMG.UserManagement.Application.ApiModels.User;
using KPMG.UserManagement.Models;
namespace KPMG.UserManagement.Application.Services
{
    public interface IUserService
    {
        public UserAuthResponseApiModel AuthenticateUser(UserAuthRequestApiModel userAuthRequestmodel);
        public RegisterUserApiResponse RegisterUser(RegisterUserApiRequest registeruserapimodel,params ApplicationRole[] userroles);
        public UpdateUserApiResponse UpdateUser(UpdateUserApiRequest updateuserrequest);
        public bool DeleteUser(UserApiModel userApiModel);
        public UserApiModel GetUserById(int userid);
        public UserApiModel GetUserByName(string username);
        public UserListApiModel GetAllUsers();
    }
}
