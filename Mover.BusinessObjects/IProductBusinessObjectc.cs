
namespace Mover.CandidateTest.BusinessObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Mover.CandidateTest.Models;
    /// <summary>
    /// interface IProductBusinessObject
    /// </summary>
    public interface IProductBusinessObject
    {
        /// <summary>
        /// Create New Product
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool CreateProduct(Product entity);
        /// <summary>
        /// Get ProductBy Id PrimaryKey
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Product GetProductById(int Id);
        /// <summary>
        /// Get Product By SKUCode
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Product GetProductBySKUCode(string code);
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        IQueryable<Product> GetAllProducts();
        /// <summary>
        /// Update Product Quantity for specific SKU
        /// </summary>
        /// <param name="SKUCode"></param>
        /// <param name="quanity"></param>
        /// <returns></returns>
        bool UpdateProductQuantity(string SKUCode, int quanity);
        /// <summary>
        /// Revove Product Quantity for specific SKU
        /// </summary>
        /// <param name="SKUCode"></param>
        /// <param name="quanity"></param>
        /// <returns></returns>
        bool RemoveProductQuantity(string SKUCode, int quanity);
    }
}
