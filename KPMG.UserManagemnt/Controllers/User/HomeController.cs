
namespace KPMG.UserManagement.Controllers.User
{
    using System.Net.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System.Text;
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {


        public HomeController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return base.Content("<div>Welcome -User Management API</div>" +
                "<p>Register User : http://localhost:53712/api/user/Register</p>"+
                "<p>Login User : http://localhost:53712/api/user/Authenticate{&quotUserName&quot:AdminUser,&quotPassword&quot:&quotadmin&quot} </p> " +
                "<p>Update User : http://localhost:53712/api/user/Update</p>" , 
                "text /html");

        }
    }
    }
