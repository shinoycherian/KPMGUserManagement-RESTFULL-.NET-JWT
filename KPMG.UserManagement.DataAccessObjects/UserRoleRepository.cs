
namespace KPMG.UserManagement.DataAccessObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading.Tasks;
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;
	using KPMG.UserManagement.Models;
	using System.Data.Entity.Core.Objects;
	/// <summary>
	/// Product Repository
	/// </summary>
	public class UserRoleRepository
	{
		private IRepository<UserRole> _repository { get; set; }
		public IRepository<UserRole> Repository
		{
			get { return _repository; }
			set { _repository = value; }
		}

		public UserRoleRepository(IRepository<UserRole> repository)
		{
			Repository = repository;
		}

		/// <summary>
		/// Alls enties 
		/// </summary>
		/// <returns>Alls enties</returns>
		public IQueryable<UserRole> All()
		{
			return Repository.All();
		}
		/// <summary>
		/// Saves this instance.
		/// </summary>
		public void Save()
		{
			Repository.Save();
		}
		/// <summary>
		/// Adds the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Add(UserRole entity)
		{
			Repository.Add(entity);
		}
		/// <summary>
		/// Get Product By SKU Code.
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public UserRole GetByUserId(int userid)
		{  
			if (this._repository.All().Count<UserRole>()>0)
			{
				return this._repository.Single(e => e.User.Id == userid);
			}
			return null;
		}		
	}

}
