using Moq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mover.CandidateTest.Models;
using Mover.CandidateTest.Application.Services;
using Mover.CandidateTest.BusinessObjects;
using Mover.CandidateTest.Application.ApiModels.Product;
using MoverCandidateTest.Controllers.Product;
namespace Mover.CandidateTest.Test.UnitTest
{

    [TestClass]
    public class ProductControllerTest
    {
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
            ProductController productcontroller = new ProductController(productService);
                     
            var result= productcontroller.AddProduct(product);
            Assert.IsNotNull(result);

        }
        public ProductApiModel CreateProductViewModel()
        {
            var Product = new ProductApiModel
            {
                SKUCode = "SKU0000001000",
                Name = "SONY TV SHAJKAKJ",
                Description = "Sony TV SHAJKAKJ",
                Quantity = 100,
                Price = 1000

            };
            return Product;
        }
        public Product CreateProductModel()
        {
            var Product = new Product
            {
                SKUCode = "SKU000001234123",
                Name = "PHILIPS TV TYQEUI",
                Description = "SAMSUNG TV TYQEUI",
                Quantity = 100,
                Price = 1000

            };
            return Product;
        }
    }
}
