using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;


namespace FitnessArchitecture.DAL.Repositories
{
	public class SleepRepository : IBaseRepository<Sleep>
	{
		private readonly AppDbContext appDbContext;
		public SleepRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task Create(Sleep sleep)
		{
			await appDbContext.AddAsync(sleep);
			await appDbContext.SaveChangesAsync();
		}

		public async Task Delete(Sleep sleep)
		{
			appDbContext.Remove(sleep);
			await appDbContext.SaveChangesAsync();
		}

		public async Task<Sleep> Update(Sleep sleep)
		{
			appDbContext.Update(sleep);
			await appDbContext.SaveChangesAsync();
			return sleep;
		}

		public IQueryable<Sleep> GetAll()
		{
			return appDbContext.Sleeps;
		}
	}
}
