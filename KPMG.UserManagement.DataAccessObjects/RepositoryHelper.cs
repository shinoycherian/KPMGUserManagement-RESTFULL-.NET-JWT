
namespace KPMG.UserManagement.DataAccessObjects
{
	public static class RepositoryHelper
    {

		public static IRepository<T> GetRepository<T>()
		{
			return ObjectFactory.GetInstance<IRepository<T>>();
		}

		public static IUnitOfWork GetUnitOfWork()
		{
			return ObjectFactory.GetInstance<IUnitOfWork, IObjectContext>(GetDbContext());
		}

		public static IUnitOfWork GetUnitOfWork(IObjectContext objectcontext)
		{
			return ObjectFactory.GetInstance<IUnitOfWork, IObjectContext>(objectcontext);
		}

		public static IObjectContext GetDbContext()
		{
			return ObjectFactory.GetInstance<IObjectContext>();
		}

		public static UserRepository GetUserRepository()
		{
			return ObjectFactory.GetInstance<UserRepository>();
		}
		public static RoleRepository GetRoleRepository()
		{
			return ObjectFactory.GetInstance<RoleRepository>();
		}
        public static UserRoleRepository GetUserRoleRepository()
        {
            return ObjectFactory.GetInstance<UserRoleRepository>();
        }
        /// <summary>
        /// GetUserRepository
        /// </summary>
        /// <param name="objectcontext"></param>
        /// <returns></returns>
        public static UserRepository GetUserRepository(IObjectContext objectcontext)
		{
			return ObjectFactory.GetInstance<UserRepository, IObjectContext>(objectcontext);
		}
		public static RoleRepository GetRoleRepository(IObjectContext objectcontext)
		{
			return ObjectFactory.GetInstance<RoleRepository,IObjectContext>(objectcontext);
		}
        public static UserRoleRepository GetUserRoleRepository(IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<UserRoleRepository, IObjectContext>(objectcontext);
        }
    }
}
