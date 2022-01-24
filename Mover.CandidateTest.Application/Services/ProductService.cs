using System;
using System.Collections.Generic;

namespace Mover.CandidateTest.Application.Services
{
    using Mover.CandidateTest.Models;
    using Mover.CandidateTest.BusinessObjects;
    using Mover.CandidateTest.Application.ApiModels.Product;
    using AutoMapper;
    public class ProductService :IProductService
    {

        private readonly IMapper _mapper;
        private IProductBusinessObject _productBusinessObject;
        /// <summary>
        /// ProductService
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="productbusinessobject"></param>
        public ProductService(IMapper mapper, IProductBusinessObject productbusinessobject)
        {
            this._mapper = mapper;
            this._productBusinessObject = productbusinessobject;
        }
        public bool CreateProduct(ProductApiModel productviewmodel)

        {
            var productexisting = this._productBusinessObject.GetProductBySKUCode(productviewmodel.SKUCode);
            if (productexisting == null)
            {
                var product = _mapper.Map<Product>(productviewmodel);
                this._productBusinessObject.CreateProduct(product);
            }
            else
            {
                this._productBusinessObject.UpdateProductQuantity(productviewmodel.SKUCode,productviewmodel.Quantity);

            }
            return true;
        }

        public ProductApiModel GetProductById(int id)
        {
            var product=this._productBusinessObject.GetProductById(id);
            return this._mapper.Map<ProductApiModel>(product);
        }

        public ProductApiModel GetProductBySKUCode(string code)
        {
            var product = this._productBusinessObject.GetProductBySKUCode(code);
            return this._mapper.Map<ProductApiModel>(product);
        }


        public ProductListApiModel GetAllProducts()
        {
            var products = this._productBusinessObject.GetAllProducts();
            var productlistviewmodel= this._mapper.Map<IEnumerable<ProductApiModel>>(products);


            return new ProductListApiModel()
            {
                Products = productlistviewmodel
            };
        }

        public bool UpdateProductQuantity(ProductApiModel productviewmodel, int quantitynew)

        {
            var product = _mapper.Map<Product>(productviewmodel);
            this._productBusinessObject.UpdateProductQuantity(product.SKUCode, quantitynew);
            return true;
        }
        public bool RemoveProductQuantity(ProductApiModel productviewmodel, int quantitynew)

        {
            var product = _mapper.Map<Product>(productviewmodel);
            this._productBusinessObject.RemoveProductQuantity(product.SKUCode, quantitynew);
            return true;
        }
    }
}
