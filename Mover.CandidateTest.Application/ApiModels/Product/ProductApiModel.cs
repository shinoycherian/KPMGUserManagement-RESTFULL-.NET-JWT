

namespace Mover.CandidateTest.Application.ApiModels.Product
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ProductApiModel
    {
    
       public String Id { get; set; }
       [Required]
       [StringLength(64)]
       public String SKUCode { get; set; }
       [Required]
       public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
