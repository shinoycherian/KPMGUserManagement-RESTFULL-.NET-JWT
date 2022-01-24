using Moq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mover.CandidateTest.Models;
using Mover.CandidateTest.Application.Services;
using Mover.CandidateTest.BusinessObjects;
using Mover.CandidateTest.Application.ApiModels.Product;
namespace Mover.CandidateTest.Test.UnitTest
{

    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void TestGetAllProduct()
        {
            // arrange
            var mockProductBusinessObject = new Mock<IProductBusinessObject>();
            var mockMapper = new Mock<IMapper>();            // act
            var productService = new ProductService(mockMapper.Object,mockProductBusinessObject.Object);
            var result = productService.GetAllProducts();
            Assert.IsNotNull(result);
           
        }

        [TestMethod]
        public void CreateProduct()
        {
            
             ProductApiModel product = CreateProductViewModel();         
            var mockProductBusinessObject = new Mock<IProductBusinessObject>();
            var mockMapper = new Mock<IMapper>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductApiModel, Product>();
            });
            var mapper = config.CreateMapper();
            var productService = new ProductService(mapper, mockProductBusinessObject.Object);
            bool serviceresult=  productService.CreateProduct(product);
            Assert.IsTrue(serviceresult);

        }
        public ProductApiModel CreateProductViewModel()
        {
            var Product = new ProductApiModel
            {
                SKUCode = "SKU000000019",
                Name = "SONY TV KD009GHSA",
                Description = "Sony TV KD009GHSA",
                Quantity = 100,
                Price = 1000

            };
            return Product;
        }
        public Product CreateProductModel()
        {
            var Product = new Product
            {
                SKUCode = "SKU000000014",
                Name = "SAMSUNG TV TYQEUI",
                Description = "SAMSUNG TV TYQEUI",
                Quantity = 100,
                Price = 1000

            };
            return Product;
        }
    }
}
