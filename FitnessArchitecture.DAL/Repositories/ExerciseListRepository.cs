using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;

namespace FitnessArchitecture.DAL.Repositories
{
	public class ExerciseListRepository : IBaseRepository<ExerciseList>
	{
		private readonly AppDbContext appDbContext;
		public ExerciseListRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task Create(ExerciseList exerciseList)
		{
			await appDbContext.ExerciseLists.AddAsync(exerciseList);
			await appDbContext.SaveChangesAsync();
		}

		public async Task Delete(ExerciseList exerciseList)
		{
			appDbContext.ExerciseLists.Remove(exerciseList);
			await appDbContext.SaveChangesAsync();
		}

		public async Task<ExerciseList> Update(ExerciseList exerciseList)
		{
			appDbContext.ExerciseLists.Update(exerciseList);
			await appDbContext.SaveChangesAsync();
			return exerciseList;
		}

		public IQueryable<ExerciseList> GetAll()
		{
			return appDbContext.ExerciseLists;
		}
	}
}