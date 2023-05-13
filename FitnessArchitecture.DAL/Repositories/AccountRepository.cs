using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;

namespace FitnessArchitecture.DAL.Repositories
{
	public class AccountRepository : IBaseRepository<Account>
	{
		private readonly AppDbContext appDbContext;
		public AccountRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task Create(Account account)
		{
			await appDbContext.AddAsync(account);
			await appDbContext.SaveChangesAsync();
		}

		public async Task Delete(Account account)
		{
			appDbContext.Remove(account);
			await appDbContext.SaveChangesAsync();
		}

		public async Task<Account> Update(Account account)
		{
			appDbContext.Update(account);
			await appDbContext.SaveChangesAsync();
			return account;
		}

		public IQueryable<Account> GetAll()
		{
			return appDbContext.Accounts;
		}
	}
}