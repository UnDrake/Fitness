using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;

namespace FitnessArchitecture.DAL.Repositories
{
	public class ExerciseToListRepository : IBaseRepository<ExerciseToList>
	{
		private readonly AppDbContext appDbContext;
		public ExerciseToListRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task Create(ExerciseToList addedExercise)
		{
			await appDbContext.AddAsync(addedExercise);
			await appDbContext.SaveChangesAsync();
		}

		public async Task Delete(ExerciseToList addedExercise)
		{
			appDbContext.Remove(addedExercise);
			await appDbContext.SaveChangesAsync();
		}

		public async Task<ExerciseToList> Update(ExerciseToList addedExercise)
		{
			appDbContext.Update(addedExercise);
			await appDbContext.SaveChangesAsync();
			return addedExercise;
		}

		public IQueryable<ExerciseToList> GetAll()
		{
			return appDbContext.AddedExercises;
		}
	}
}