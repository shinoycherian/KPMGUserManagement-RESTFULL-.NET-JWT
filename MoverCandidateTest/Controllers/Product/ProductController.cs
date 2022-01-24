
namespace MoverCandidateTest.Controllers.Product
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using System;
    using Mover.CandidateTest.Application.Services;
    using Mover.CandidateTest.Application.ApiModels.Product;
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProductService _productService;
        public ProductController(IProductService productservice)
        {
            _productService = productservice;
        }
        /// <summary>
        ///  Get All Product [SKUCode ,Name,Description,Quantity,Price]
        ///  
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            ProductListApiModel allprodcuts = _productService.GetAllProducts();
            if (allprodcuts != null)
            {
                return Ok(allprodcuts);
            }
            else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Get  Product [SKUCode ,Name,Description,Quantity,Price] By SKU
        /// </summary>
        /// <param name="SKUCode"></param>
        /// <returns></returns>
        [HttpGet("{SKUCode}")]
        public IActionResult GetProductBySKU(string SKUCode)
        {
            ProductApiModel product = _productService.GetProductBySKUCode(SKUCode);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Add a new Product with SKU Code.
        /// Model [SKUCode ,Name,Description,Quantity,Price]
        /// </summary>
        /// <param name="productmodel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductApiModel productmodel)
        {

           
            bool result = _productService.CreateProduct(productmodel);
            if (result == false)
            {
                throw new Exception("Error in create new Product");
            }
            return StatusCode(StatusCodes.Status201Created, productmodel);
        }
        /// <summary>
        /// Add moe Quantity to A prouct with SKUCode.
        /// </summary>
        /// <param name="skucode"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddProductQuantity([FromQuery] string skucode, [FromQuery] int quantity)
        {
            ProductApiModel product = _productService.GetProductBySKUCode(skucode);
            if (product != null)
            {
                _productService.UpdateProductQuantity(product, quantity);
                ProductApiModel productupdated = _productService.GetProductBySKUCode(skucode);
                return StatusCode(StatusCodes.Status200OK,productupdated);
            }
            throw new Exception("Error in updating Product quantity");
        }
        /// <summary>
        /// remove specific quantity of a product by SKuCode.
        /// </summary>
        /// <param name="skucode"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RemoveProductQuantity([FromQuery] string skucode, [FromQuery] int quantity)
        {
            ProductApiModel product = _productService.GetProductBySKUCode(skucode);
            if (product != null)
            {
                _productService.RemoveProductQuantity(product, quantity);
                ProductApiModel productupdated = _productService.GetProductBySKUCode(skucode);
                return StatusCode(StatusCodes.Status200OK, productupdated);
            }
            throw new Exception("Error in updating Product quantity");
        }
    }
    }
