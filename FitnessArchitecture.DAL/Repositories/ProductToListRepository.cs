using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;

namespace FitnessArchitecture.DAL.Repositories
{
	public class ProductToListRepository : IBaseRepository<ProductToList>
	{
		private readonly AppDbContext appDbContext;
		public ProductToListRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task Create(ProductToList addedProduct)
		{
			await appDbContext.AddAsync(addedProduct);
			await appDbContext.SaveChangesAsync();
		}

		public async Task Delete(ProductToList addedProduct)
		{
			appDbContext.Remove(addedProduct);
			await appDbContext.SaveChangesAsync();
		}

		public async Task<ProductToList> Update(ProductToList addedProduct)
		{
			appDbContext.Update(addedProduct);
			await appDbContext.SaveChangesAsync();
			return addedProduct;
		}

		public IQueryable<ProductToList> GetAll()
		{
			return appDbContext.AddedProducts;
		}
	}
}
