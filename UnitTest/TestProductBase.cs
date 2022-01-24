using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mover.CandidateTest.Models;
namespace Mover.CandidateTest.Test.UnitTest
{
    public class TestProductBase
    {

        public Product  CreateProduct()
        {
            var Product = new Product
            {
                SKUCode = "SKU000000010",
                Name = "SONY TV KD009GHSA",
                Description = "Sony TV KD009GHSA",
                Quantity = 100,
                Price = 1000

            };
            return Product;
        }

    }
}
