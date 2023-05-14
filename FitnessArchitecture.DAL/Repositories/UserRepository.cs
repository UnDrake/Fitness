using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;

namespace FitnessArchitecture.DAL.Repositories
{
	public class UserRepository : IBaseRepository<User>
	{
		private readonly AppDbContext appDbContext;
		public UserRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task Create(User user)
		{
			await appDbContext.Users.AddAsync(user);
			await appDbContext.SaveChangesAsync();
		}

		public async Task Delete(User user)
		{
			appDbContext.Remove(user);
			await appDbContext.SaveChangesAsync();
		}

		public async Task<User> Update(User user)
		{
			appDbContext.Update(user);
			await appDbContext.SaveChangesAsync();
			return user;
		}

		public IQueryable<User> GetAll()
		{
			return appDbContext.Users;
		}
	}
}