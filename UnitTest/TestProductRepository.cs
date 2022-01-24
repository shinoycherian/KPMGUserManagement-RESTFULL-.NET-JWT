using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Mover.CandidateTest.Models;
using Mover.CandidateTest.DataAccessObjects;
namespace Mover.CandidateTest.Test.UnitTest
{
    [TestClass]
    public class TestProductRepository:TestProductBase
    {
        [TestMethod]
        public void TestCreateProduct()
        {
            Product product = base.CreateProduct();

            ProductRepository productRepository = RepositoryHelper.GetProductRepository();
            productRepository.Add(product);
            productRepository.Save();
            IEnumerable<Product> productList = productRepository.Repository.Find(p => p.SKUCode == product.SKUCode);
            Assert.IsNotNull(productList);
           
        }
        
    }
}
