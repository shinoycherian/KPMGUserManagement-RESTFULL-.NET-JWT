

namespace KPMG.UserManagement.Application.Security.Tokens
{
    using KPMG.UserManagement.Models;
    using System.Collections.Generic;
    public interface ITokenHandler
    {
         AccessToken CreateAccessToken(User user);
         RefreshToken TakeRefreshToken(string token);
         void RevokeRefreshToken(string token);
         List<string> GetClaims(string token, string claimType);
    }
}