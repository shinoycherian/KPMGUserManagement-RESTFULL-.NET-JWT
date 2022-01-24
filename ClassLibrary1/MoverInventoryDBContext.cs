using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using Mover.CandidateTest.Models;
    

namespace Mover.CandidateTest.DataAccessObjects
{
    public class MoverInventoryDBContext:DbContext
    {

        public MoverInventoryDBContext() : base("MoverInventoryDB")
        { }
 
        
        public virtual DbSet<Product> Products { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
