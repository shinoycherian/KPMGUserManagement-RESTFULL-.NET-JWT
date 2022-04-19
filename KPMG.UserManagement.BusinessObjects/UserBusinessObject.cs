
namespace KPMG.UserManagement.BusinessObjects
{
  
    using System.Linq;
    using KPMG.UserManagement.Models;
    using KPMG.UserManagement.DataAccessObjects;
    /// <summary>
    /// userBusinessObject class Implements IuserBusinessObject.
    /// </summary>
    public class UserBusinessObject : IUserBusinessObject
    {

        private readonly IUnitOfWork _uow;
        private readonly UserRepository _userrepository;
       // private readonly UserRoleRepository _userrolerepository;
        private readonly RoleRepository _rolerepository;
        private readonly IObjectContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        public UserBusinessObject()
        {

            this._context = RepositoryHelper.GetDbContext();
            this._uow = RepositoryHelper.GetUnitOfWork(_context);
            this._userrepository = RepositoryHelper.GetUserRepository(_context);
            this._rolerepository= RepositoryHelper.GetRoleRepository(_context);
           // this._userrolerepository = RepositoryHelper.GetUserRoleRepository(_context);

        }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="lazyloaded"></param>
        /// <param name="proxyenabled"></param>
        public UserBusinessObject(bool lazyloaded, bool proxyenabled)
        {

            this._context = RepositoryHelper.GetDbContext();

            this._context.LazyLoadingEnabled = lazyloaded;
            this._context.ProxyCreationEnabled = proxyenabled;

            this._uow = RepositoryHelper.GetUnitOfWork(_context);
            this._userrepository = RepositoryHelper.GetUserRepository(_context);
            this._rolerepository = RepositoryHelper.GetRoleRepository(_context);
          //  this._userrolerepository = RepositoryHelper.GetUserRoleRepository(_context);
        }
        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CreateUser(User user)
        {
        
                this._userrepository.Add(user);
                this._userrepository.Save();
                return true;
        }
        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CreateUserWIthRole(User user,params ApplicationRole[] userroles)
        {
            var userrolenames = userroles.Select(r => r.ToString()).ToList();
            var roles =  this._rolerepository.All().Where(r => userrolenames.Contains(r.Name)).ToList();

            foreach (var role in roles)
            {
                
                user.Roles.Add(role );
            }
           
            this._userrepository.Add(user);
            this._userrepository.Save();
           // this._userrolerepository.Save();
            
            return true;
        }

        /// <summary>
        /// Dels the user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The delete user.
        /// </returns>
        public bool DeleteUser(User user)
        {
            this._userrepository.Delete(user);
            this._userrepository.Save();
            return true;
        }

        /// <summary>
        /// Get the user.
        /// </summary>
        /// <param name="username">
        /// The pid.
        /// </param>
        /// <returns>Single entity</returns>
        public User GetByUserName(string username)
        {
            return this ._userrepository.GetByUserName(username);
        }
        /// <summary>
        /// Get the user.
        /// </summary>
        /// <param name="id">
        /// The pid.
        /// </param>
        /// <returns>Single entity</returns>
        public User GetByUserId(int userid)
        {
            return this._userrepository.GetByUserId(userid);
        }
        /// <summary>
        /// Get the user.
        /// </summary>
        /// <param name="id">
        /// The pid.
        /// </param>
        /// <returns>Single entity</returns>
        //public UserRole GetByUserRoleByUserId(int userid)
        //{
        //    return this._userrolerepository.GetByUserId(userid);
        //}
        /// <summary>
        /// Get the user.
        /// </summary>
        /// <param name="name">
        /// The pid.
        /// </param>
        /// <returns>Single entity</returns>

        public User GetByUserNameAndPwd(string username,string password)
        {
            return this._userrepository.GetByUserNameAndPwd(username,password);
        }
        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The update user.
        /// </returns>
        public User UpdateUser(User user)
        {
            this._userrepository.Save();
            return user;
        }
       
        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns></returns>
        public IQueryable<User> GetAllUsers()
        {
            return this._userrepository.All();

        }
    }
}
