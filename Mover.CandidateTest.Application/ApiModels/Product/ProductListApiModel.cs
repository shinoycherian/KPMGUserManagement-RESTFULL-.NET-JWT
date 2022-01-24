

namespace Mover.CandidateTest.Application.ApiModels.Product
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class ProductListApiModel
    {
       
       public IEnumerable<ProductApiModel> Products { get; set; }
      
   
    }
}
