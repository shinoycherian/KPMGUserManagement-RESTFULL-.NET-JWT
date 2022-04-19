
namespace KPMG.UserManagement.BusinessObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KPMG.UserManagement.Models;
    /// <summary>
    /// interface IProductBusinessObject
    /// </summary>
    public interface IUserBusinessObject
    {
        /// <summary>
        /// Create New Product
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool CreateUser(User entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userroles"></param>
        /// <returns></returns>
        public bool CreateUserWIthRole(User user, params ApplicationRole[] userroles);
        /// <summary>
        /// Get ProductBy Id PrimaryKey
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetByUserName(string username);

        /// <summary>
        /// Get ProductBy Id PrimaryKey
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        User GetByUserId(int userid);
        /// <summary>
        /// Get ProductBy Id PrimaryKey
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        User GetByUserNameAndPwd(string usernmae,string password);
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        IQueryable<User> GetAllUsers();
        /// <summary>
        /// Create New Product
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteUser(User user);
        /// <summary>
        /// Get ProductBy Id PrimaryKey
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User UpdateUser(User user);
        /// <summary>
        /// GetByUserRoleByUserId.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        //public UserRole GetByUserRoleByUserId(int userid);

    }
}
