using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.UserManagement.Application.ApiModels.User
{
    public class UserListApiModel
    {
        public IEnumerable<UserApiModel> Users { get; set; }
    }
}
