using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessArchitecture.DAL.Repositories
{
	public class ProductRepository : IBaseRepository<Product>
	{
		private readonly AppDbContext appDbContext;
		public ProductRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task Create(Product product)
		{
			await appDbContext.AddAsync(product);
			await appDbContext.SaveChangesAsync();
		}

		public async Task Delete(Product product)
		{
			appDbContext.Remove(product);
			await appDbContext.SaveChangesAsync();
		}

		public async Task<Product> Update(Product product)
		{
			appDbContext.Update(product);
			await appDbContext.SaveChangesAsync();
			return product;
		}

		public IQueryable<Product> GetAll()
		{
			return appDbContext.Products;
		}
	}
}
