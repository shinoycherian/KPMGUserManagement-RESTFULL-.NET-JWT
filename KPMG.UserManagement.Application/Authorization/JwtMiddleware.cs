namespace KPMG.UserManagement.Application.Authorization
{
    using Microsoft.Extensions.Options;
    using Microsoft.AspNetCore.Http;
    using System.Configuration;
    using System.Linq;
    using System.Threading.Tasks;
    using KPMG.UserManagement.Application.Services;

    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
       

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
           
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetUserById(userId.Value);
            }

            await _next(context);
        }
    }
}