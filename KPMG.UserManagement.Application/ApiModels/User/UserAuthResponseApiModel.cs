using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPMG.UserManagement.Models;
namespace KPMG.UserManagement.Application.ApiModels.User
{
    public class UserAuthResponseApiModel
    {
    
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }

        public UserAuthResponseApiModel(bool success,string message, string token)
        {
            Success = success;
            Message = message;
            Token = token;
        }
    }
}
