
namespace Mover.CandidateTest.DataAccessObjects
{
    using System.Data.Entity;
    using Mover.CandidateTest.Models;
    /// <summary>
    /// Inventory DB Context extends DbContext
    /// </summary>
    public class MoverInventoryDBContext:DbContext
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public MoverInventoryDBContext() : base("MoverInventoryDB")
        { }
        /// <summary>
        /// Product DB Set
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
