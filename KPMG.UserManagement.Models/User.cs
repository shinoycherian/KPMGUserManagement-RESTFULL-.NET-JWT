
namespace KPMG.UserManagement.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// user Model.
    /// </summary>
    public class User
    {
       /// <summary>
       /// Primar Key Id
       /// </summary>
      
       public int Id { get; set; }
        /// <summary>
        /// FirstName
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        /// <summary>
        /// SecondName
        /// </summary>
        ///  [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        /// <summary>
        /// UserName.
        /// </summary>
        ///  [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string PasswordHash { get; set; }


        public ICollection<Role> Roles { get; set; } = new Collection<Role>();

    }
}
