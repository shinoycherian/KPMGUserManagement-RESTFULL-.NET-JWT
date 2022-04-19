
namespace KPMG.UserManagement.DataAccessObjects
{
    using System.Data.Entity;
    using KPMG.UserManagement.Models;
    /// <summary>
    /// Inventory DB Context extends DbContext
    /// </summary>
    public class UserManagementDBContext:DbContext
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public UserManagementDBContext() : base("KPMGUserManagementDB")
        {

            Database.SetInitializer<UserManagementDBContext>(
                new DropCreateDatabaseIfModelChanges<UserManagementDBContext>());
        }
        /// <summary>
        /// user DB Set
        /// </summary>
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
       // public virtual DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        }
       

    }
}
