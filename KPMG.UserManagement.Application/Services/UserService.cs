

namespace KPMG.UserManagement.Application.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using KPMG.UserManagement.Models;
    using KPMG.UserManagement.BusinessObjects;
    using KPMG.UserManagement.Application.ApiModels.User;
    using KPMG.UserManagement.Application.Authorization;
    using KPMG.UserManagement.Application.Security;
    using KPMG.UserManagement.Application.Security.Tokens;
    using AutoMapper;
    using BCrypt.Net;
    public class UserService :IUserService
    {

        private readonly IMapper _mapper;
        private IUserBusinessObject _userBusinessObject;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenHandler _tokenHandler;
        /// <summary>
        /// userService
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="nameobject"></param>
        public UserService(IMapper mapper, IUserBusinessObject userbusinessobject, IPasswordHasher passwordHasher,ITokenHandler tokenHandler)
        {
            this._mapper = mapper;
            this._userBusinessObject = userbusinessobject;
            this._passwordHasher = passwordHasher;
            this._tokenHandler = tokenHandler;
        }
        /// <summary>
        /// RegisterUser 
        /// </summary>
        /// <param name="registerusermodel"></param>
        /// <returns>RegisterUserApiResponse</returns>
        public RegisterUserApiResponse RegisterUser(RegisterUserApiRequest registerusermodel,params ApplicationRole[] userroles)
        {
            //check if no user exists.
                    
            if (this._userBusinessObject.GetAllUsers().Count() ==0)
            {
                //Administrator user.
                var user = _mapper.Map<User>(registerusermodel);
                user.PasswordHash = this._passwordHasher.HashPassword(registerusermodel.Password);
                this._userBusinessObject.CreateUserWIthRole(user, ApplicationRole.Administrator);
            }
            else
            {
                var userexisting = this._userBusinessObject.GetByUserName(registerusermodel.UserName);
                if (userexisting == null)
                {
                    var user = _mapper.Map<User>(registerusermodel);
                    user.PasswordHash = this._passwordHasher.HashPassword(registerusermodel.Password);
                    this._userBusinessObject.CreateUserWIthRole(user, userroles);
                }
            }
            //Get the user by username.
            var usercreated = this._userBusinessObject.GetByUserName(registerusermodel.UserName);
            return this._mapper.Map<RegisterUserApiResponse>(usercreated);
           
        }

        /// <summary>
        /// GetUserById
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>UserApiModel</returns>
        public UserApiModel GetUserById(int userid)
        {
            var user=this._userBusinessObject.GetByUserId(userid);
            return this._mapper.Map<UserApiModel>(user);
        }
        /// <summary>
        /// GetUserByName,
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserApiModel GetUserByName(string username)
        {
            var user = this._userBusinessObject.GetByUserName(username);
            return this._mapper.Map<UserApiModel>(user);
        }

        /// <summary>
        /// DeleteUser.
        /// </summary>
        /// <param name="userApiModel"></param>
        /// <returns></returns>
        public bool DeleteUser(UserApiModel userApiModel)
        {
            var userenbusinessobj = _mapper.Map<User>(userApiModel);
            var result = this._userBusinessObject.DeleteUser(userenbusinessobj);
            return result;
        }
        /// <summary>
        /// UpdateUser.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UpdateUserApiResponse UpdateUser(UpdateUserApiRequest updateuserrequest)
        {
            var userexisting = this._userBusinessObject.GetByUserId(updateuserrequest.Id);
            if (userexisting != null)
            {
                return new UpdateUserApiResponse(false, "The user does not exist", null);
            }
            var user = _mapper.Map<User>(updateuserrequest);
            user.PasswordHash = this._passwordHasher.HashPassword(updateuserrequest.Password);
            this._userBusinessObject.UpdateUser(user);

            return new UpdateUserApiResponse(false, "The user updated", user.UserName);
        }
            /// <summary>
            /// UpdateUser
            /// </summary>
            /// <returns></returns>
        public UserListApiModel GetAllUsers()
        {
            var users = this._userBusinessObject.GetAllUsers();
            var userlistviewmodel= this._mapper.Map<IEnumerable<UserApiModel>>(users);
            return new UserListApiModel()
            {
                Users = userlistviewmodel
            };
        }
        /// <summary>
        /// AuthenticateUser,
        /// </summary>
        /// <param name="userauthequestmodel"></param>
        /// <returns></returns>
        public UserAuthResponseApiModel AuthenticateUser(UserAuthRequestApiModel userauthequestmodel)
        {
            var user = this._userBusinessObject.GetByUserName(userauthequestmodel.UserName);
             // validate.

            if (user == null || !this._passwordHasher.PasswordMatches(userauthequestmodel.Password, user.PasswordHash))
            {
                return new UserAuthResponseApiModel(false, "Username or password is incorrect", null);

            }
            // authentication successful ,so generate jwt token
            
            var jwtAccessToken = _tokenHandler.CreateAccessToken(user);

            return new UserAuthResponseApiModel(true,null, jwtAccessToken.Token);
        }

        public bool IsAdminUser(string token)
        {
           return _tokenHandler.GetClaims(token,"Administrator")
                .Contains(ApplicationRole
                .Administrator.ToString());
        }
    }
}
