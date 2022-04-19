using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
namespace KPMG.UserManagement.DataAccessObjects
{
    public class EFRepository<T> : IRepository<T>
                                      where T : class
    {

        private readonly IObjectSet<T> _objectset;
        private readonly IObjectContext _objectContext;
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EFRepository{T}"/> class. 
        /// Initializes a new instance of the <see cref="EFRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="objectContext">
        /// The object context.
        /// </param>
        public EFRepository(IObjectContext objectContext)
        {
            this._objectset = objectContext.CreateObjectSet<T>();
            this._objectContext = objectContext;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the object set.
        /// </summary>
        /// <value>The object set.</value>
        private IObjectSet<T> ObjectSet
        {
            get
            {
                return this._objectset;
            }
        }
        #endregion
        #region Interface Implementation

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Add(T entity)
        {
            this._objectset.AddObject(entity);
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>
        /// collection of entities
        /// </returns>
        public virtual IQueryable<T> All()
        {
            return this.ObjectSet.AsQueryable();
        }

        public void Delete(T entity)
        {
            this._objectset.DeleteObject(entity);
        }

        public void Save()
        {
            this._objectContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await this._objectContext.SaveChangesAsync();
        }

        public IEnumerable<T> Find(
        Expression<Func<T, bool>> expression)
        {
            return this._objectset.Where(expression);
        }

        public T Single(Expression<Func<T, bool>> where)
        {            
            return this._objectset.SingleOrDefault(where);
        }


        #endregion
    }
}
