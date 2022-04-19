
namespace KPMG.UserManagement.Controllers.User
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System;
    using KPMG.UserManagement.Application.Services;
    using KPMG.UserManagement.Application.ApiModels.User;
    using KPMG.UserManagement.Models;
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService _userService;
        public UserController(IUserService userservice)
        {
            _userService = userservice;
        }

        /// <summary>
        ///  Get All Users,
        ///  
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult GetAllUsers()
        {
            UserListApiModel allusers = _userService.GetAllUsers();
            if (allusers != null)
            {
                return Ok(allusers);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Authenticate User.
        /// </summary>
        /// <param name="userauthrequestmodel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserAuthRequestApiModel userauthrequestmodel)
        {
            var response = _userService.AuthenticateUser(userauthrequestmodel);
            return Ok(response);
        }
        /// <summary>
        /// Create a new user with FirstName,LastNam,UserName ,Password ,.
        /// </summary>
        /// <param name="registerusermodel"></param>
        /// <returns></returns>
        /// 
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterUserApiRequest registerusermodel)
        {
            RegisterUserApiResponse result = this._userService.RegisterUser(registerusermodel, ApplicationRole.User);
            if (result == null)
            {
                throw new Exception("Error in create user");
            }
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// update a new user .
        /// Model [Firstlname, LastName,Password].
        /// </summary>
        /// <param name="usermodel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Update([FromBody] UpdateUserApiRequest updateuserrequest)
        {
            UpdateUserApiResponse result = this._userService.UpdateUser(updateuserrequest);
            if (result == null)
            {
                throw new Exception("Error in update user");
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }
        /// <summary>
        /// Delete User by user Id.
        /// </summary>
        /// <param name="usermodel"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            UserApiModel user = this._userService.GetUserById(id);

            if (user == null)
            {
                return NotFound("User Does not Exist.");
            }
            bool result=this._userService.DeleteUser(user);
            if(!result)
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error deleting data");
            return StatusCode(StatusCodes.Status200OK, user);
        }
    }
    }
