using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.UserManagement.Application.ApiModels.User
{
    public class UpdateUserApiResponse
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public UpdateUserApiResponse(bool success, string message,string username)
        {
            Success = success;
            Message = message;
            UserName = username;
            
        }
    }
}
