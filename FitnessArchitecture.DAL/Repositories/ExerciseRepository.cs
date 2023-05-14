using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;

namespace FitnessArchitecture.DAL.Repositories
{
	public class ExerciseRepository : IBaseRepository<Exercise>
	{
		private readonly AppDbContext appDbContext;
		public ExerciseRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task Create(Exercise exercise)
		{
			await appDbContext.Exercises.AddAsync(exercise);
			await appDbContext.SaveChangesAsync();
		}

		public async Task Delete(Exercise exercise)
		{
			appDbContext.Remove(exercise);
			await appDbContext.SaveChangesAsync();
		}
		public async Task<Exercise> Update(Exercise exercise)
		{
			appDbContext.Update(exercise);
			await appDbContext.SaveChangesAsync();
			return exercise;
		}

		public IQueryable<Exercise> GetAll()
		{
			return appDbContext.Exercises;
		}
	} 
}