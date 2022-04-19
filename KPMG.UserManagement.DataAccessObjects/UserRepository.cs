
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
	public class UserRepository
	{
		private IRepository<User> _repository { get; set; }

		public IRepository<User> Repository
		{
			get { return _repository; }
			set { _repository = value; }
		}

		public UserRepository(IRepository<User> repository)
		{
			Repository = repository;
		}

		/// <summary>
		/// Alls enties 
		/// </summary>
		/// <returns>Alls enties</returns>
		public IQueryable<User> All()
		{
			return Repository.All();
		}

		/// <summary>
		/// Adds the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Add(User entity)
		{
			Repository.Add(entity);
		}
		public User GetByPk(int Id)
		{
			return this._repository.Single(e => e.Id == Id);
		}

		/// <summary>
		/// Deletes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Delete(User entity)
		{
			Repository.Delete(entity);
		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		public void Save()
		{
			Repository.Save();
		}

		/// <summary>
		/// SaveAsync
		/// </summary>
		public async Task<int> SaveAsync()
		{
			return await Repository.SaveAsync();
		}
		/// <summary>
		/// Get Product By SKU Code.
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public User GetByUserName(string username)
		{  
			if (this._repository.All().Count<User>()>0)
			{
				return this._repository.Single(e => e.UserName == username);
				
			}
			return null;
		}
		/// <summary>
		/// Get Product By SKU Code.
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public User GetByUserId(int userid)
		{
			if (this._repository.All().Count<User>() > 0)
			{
				return this._repository.Single(e => e.Id == userid);
			}
			return null;
		}
		public User GetByUserNameAndPwd(string username,string password)
		{
			if (this._repository.All().Count<User>() > 0)
			{
				return this._repository.Single(e => e.UserName == username && e.PasswordHash==password);
			}
			return null;
		}
	}

}
