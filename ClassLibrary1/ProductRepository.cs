using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Mover.CandidateTest.Models;
using System.Data.Entity.Core.Objects;
namespace Mover.CandidateTest.DataAccessObjects
{
    public class ProductRepository
	{
		private IRepository<Product> _repository { get; set; }
		public IRepository<Product> Repository
		{
			get { return _repository; }
			set { _repository = value; }
		}

		public ProductRepository(IRepository<Product> repository)
		{
			Repository = repository;
		}

		/// <summary>
		/// Alls enties 
		/// </summary>
		/// <returns>Alls enties</returns>
		public IQueryable<Product> All()
		{
			return Repository.All();
		}

		/// <summary>
		/// Adds the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Add(Product entity)
		{
			Repository.Add(entity);
		}
		public Product GetByPk(int Id)
		{
			return this._repository.Single(e => e.Id == Id);
		}

		/// <summary>
		/// Deletes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Delete(Product entity)
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
	}

}
