
namespace Mover.CandidateTest.DataAccessObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {

        #region Public Methods

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Add(T entity);

        /// <summary>
        /// Get all dataset
        /// </summary>
        /// <returns>
        /// collection of entits
        /// </returns>
        IQueryable<T> All();

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Delete(T entity);       
        /// <summary>
        /// Singles the specified where.
        /// </summary>
        /// <param name="where">
        /// The where.
        /// </param>
        /// <returns>
        /// Single entity
        /// </returns>
        T Single(Expression<Func<T, bool>> where);
        /// <summary>
        /// Finds the specified expression.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// IEmunerable entites
        /// </returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves with async.
        /// </summary>
        Task<int> SaveAsync();
        #endregion
    }
}
