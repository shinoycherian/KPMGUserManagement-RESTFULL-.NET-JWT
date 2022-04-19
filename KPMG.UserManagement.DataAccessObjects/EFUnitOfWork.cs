using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.UserManagement.DataAccessObjects
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {

        #region Constants and Fields

        /// <summary>
        /// The _object context.
        /// </summary>
        private readonly IObjectContext _objectContext;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EFUnitOfWork"/> class.
        /// </summary>
        /// <param name="objectContext">
        /// The object context.
        /// </param>
        public EFUnitOfWork(IObjectContext objectContext)
        {
            this._objectContext = objectContext;
        }

        #endregion

        #region Implemented Interfaces

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._objectContext != null)
            {
                this._objectContext.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        #endregion

        #region IUnitOfWork

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            this._objectContext.SaveChanges();
        }

        /// <summary>
        /// SaveChangesAsync
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveAsync()
        {
            return await this._objectContext.SaveChangesAsync();
        }


        #endregion

        #endregion
    }
}
