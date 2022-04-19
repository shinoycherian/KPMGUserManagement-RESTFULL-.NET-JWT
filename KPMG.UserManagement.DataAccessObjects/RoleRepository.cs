
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
	/// user Repository
	/// </summary>
	public class RoleRepository
	{
		private IRepository<Role> _repository { get; set; }
		public IRepository<Role> Repository
		{
			get { return _repository; }
			set { _repository = value; }
		}

		public RoleRepository(IRepository<Role> repository)
		{
			Repository = repository;
		}

		/// <summary>
		/// Alls enties 
		/// </summary>
		/// <returns>Alls enties</returns>
		public IQueryable<Role> All()
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
		/// Saves this instance.
		/// </summary>
		public void Add(Role entity)
		{
			Repository.Add(entity);
		}
		/// <summary>
		/// Get user By SKU Code.
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public Role GetByRoleName(string rolename)
		{  
			if (this._repository.All().Count<Role>()>0)
			{
				return this._repository.Single(e => e.Name == rolename);
			}
			return null;
		}		
	}

}
