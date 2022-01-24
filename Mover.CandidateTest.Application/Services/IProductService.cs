
namespace Mover.CandidateTest.Application.Services
{
    using Mover.CandidateTest.Application.ApiModels.Product;
    public interface IProductService
    {
        /// <summary>
        /// CreateProduct
        /// </summary>
        /// <param name="productviewmodel"></param>
        /// <returns></returns>
        public bool CreateProduct(ProductApiModel productviewmodel);

        /// <summary>
        /// GetProductById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ProductApiModel GetProductById(int Id);
        /// <summary>
        /// GetProductByCode
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ProductApiModel GetProductBySKUCode(string code);
        /// <summary>
        /// GetAllProducts
        /// </summary>
        /// <returns></returns>
        public ProductListApiModel GetAllProducts();

        /// <summary>
        /// UpdateProductQuantity
        /// </summary>
        /// <param name="productviewmodel"></param>
        /// <returns></returns>
        public bool UpdateProductQuantity(ProductApiModel productviewmodel, int quantitynew);
        /// <summary>
        /// RemoveProductQuantity
        /// </summary>
        /// <param name="productviewmodel"></param>
        /// <returns></returns>
        public bool RemoveProductQuantity(ProductApiModel productviewmodel, int quantitynew);
    }
}
