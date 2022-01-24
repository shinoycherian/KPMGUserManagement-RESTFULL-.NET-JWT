
namespace Mover.CandidateTest.DataAccessObjects
{
	public static class RepositoryHelper
    {

		public static IRepository<T> GetRepository<T>()
		{
			return ObjectFactory.GetInstance<IRepository<T>>();
		}

		public static IUnitOfWork GetUnitOfWork()
		{
			return ObjectFactory.GetInstance<IUnitOfWork, IObjectContext>(GetDbContext());
		}

		public static IUnitOfWork GetUnitOfWork(IObjectContext objectcontext)
		{
			return ObjectFactory.GetInstance<IUnitOfWork, IObjectContext>(objectcontext);
		}

		public static IObjectContext GetDbContext()
		{
			return ObjectFactory.GetInstance<IObjectContext>();
		}


		public static ProductRepository GetProductRepository()
		{
			return ObjectFactory.GetInstance<ProductRepository>();
		}

		public static ProductRepository GetProductRepository(IObjectContext objectcontext)
		{
			return ObjectFactory.GetInstance<ProductRepository, IObjectContext>(objectcontext);
		}

	}
}
