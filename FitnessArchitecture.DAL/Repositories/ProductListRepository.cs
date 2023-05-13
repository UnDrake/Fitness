using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;


namespace FitnessArchitecture.DAL.Repositories
{
	public class ProductListRepository : IBaseRepository<ProductList>
	{
		private readonly AppDbContext appDbContext;
		public ProductListRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task Create(ProductList productList)
		{
			await appDbContext.ProductLists.AddAsync(productList);
			await appDbContext.SaveChangesAsync();
		}

		public async Task Delete(ProductList productList)
		{
			appDbContext.ProductLists.Remove(productList);
			await appDbContext.SaveChangesAsync();
		}

		public async Task<ProductList> Update(ProductList productList)
		{
			appDbContext.ProductLists.Update(productList);
			await appDbContext.SaveChangesAsync();
			return productList;
		}

		public IQueryable<ProductList> GetAll()
		{
			return appDbContext.ProductLists;
		}
	}
}
