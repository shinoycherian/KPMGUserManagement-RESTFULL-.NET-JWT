
namespace Mover.CandidateTest.Models
{
    using System;
    using System.ComponentModel.;
    /// <summary>
    /// Product Model.
    /// </summary>
    public class Product
    {
       /// <summary>
       /// Primar Key Id
       /// </summary>
       public int Id { get; set; }
        /// <summary>
        /// SKU Code
        /// </summary>
        [Key]
        public string SKUCode { get; set; }
        /// <summary>
        /// Name
        /// </summary>
       public string Name { get; set; }
        /// <summary>
        /// Description.
        /// </summary>
       public string Description { get; set; }
        /// <summary>
        /// Price
        /// </summary>
       public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
       public int Quantity { get; set; }
       //public  Supplier Supplier { get; set; }
       //public  Category Category { get; set; }

    }
}
