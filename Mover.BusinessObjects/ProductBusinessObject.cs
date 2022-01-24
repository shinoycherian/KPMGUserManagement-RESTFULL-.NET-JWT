
namespace Mover.CandidateTest.BusinessObjects
{
  
    using System.Linq;
    using Mover.CandidateTest.Models;
    using Mover.CandidateTest.DataAccessObjects;
    /// <summary>
    /// ProductBusinessObject class Implements IProductBusinessObject.
    /// </summary>
    public class ProductBusinessObject : IProductBusinessObject
    {

        private readonly IUnitOfWork uow;
        private readonly ProductRepository productrepository;
        private readonly IObjectContext context;

        /// <summary>
        /// Ctor
        /// </summary>
        public ProductBusinessObject()
        {

            this.context = RepositoryHelper.GetDbContext();
            this.uow = RepositoryHelper.GetUnitOfWork(context);
            this.productrepository = RepositoryHelper.GetProductRepository(context);

        }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="lazyloaded"></param>
        /// <param name="proxyenabled"></param>
        public ProductBusinessObject(bool lazyloaded, bool proxyenabled)
        {

            this.context = RepositoryHelper.GetDbContext();

            this.context.LazyLoadingEnabled = lazyloaded;
            this.context.ProxyCreationEnabled = proxyenabled;

            this.uow = RepositoryHelper.GetUnitOfWork(context);
            this.productrepository = RepositoryHelper.GetProductRepository(context);

        }
        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool CreateProduct(Product product)
        {
        
                this.productrepository.Add(product);
                this.productrepository.Save();
                return true;
        }

        /// <summary>
        /// Dels the product.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The del product.
        /// </returns>
        public bool DeleteProduct(Product product)
        {
            this.productrepository.Delete(product);
            this.productrepository.Save();
            return true;
        }

        /// <summary>
        /// Get the product.
        /// </summary>
        /// <param name="id">
        /// The pid.
        /// </param>
        /// <returns>Single entity</returns>
        public Product GetProductById(int id)
        {
            return productrepository.GetByPk(id);
        }
        /// <summary>
        /// Get the product.
        /// </summary>
        /// <param name="name">
        /// The pid.
        /// </param>
        /// <returns>Single entity</returns>

        public Product GetProductBySKUCode(string code)
        {
            return productrepository.GetBySKUCode(code);
        }
        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The update product.
        /// </returns>
        public bool UpdateProduct(Product product)
        {
            this.productrepository.Save();
            return true;
        }
        /// <summary>
        /// Update Product Quantity for specific SKU
        /// </summary>
        /// <param name="SKUCode"></param>
        /// <param name="quanity"></param>
        /// <returns></returns>
        public bool UpdateProductQuantity(string SKUCode,int quanity)
        {
            Product product = GetProductBySKUCode(SKUCode);
            product.Quantity += quanity;
            this.productrepository.Save();
            return true;
        }
        /// <summary>
        /// Revove Product Quantity for specific SKU
        /// </summary>
        /// <param name="SKUCode"></param>
        /// <param name="quanity"></param>
        /// <returns></returns>
        public bool RemoveProductQuantity(string SKUCode, int quanity)
        {
            Product product = GetProductBySKUCode(SKUCode);
            product.Quantity -= quanity;
            this.productrepository.Save();
            return true;
        }
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetAllProducts()
        {
            return productrepository.All();

        }
    }
}
