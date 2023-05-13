using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;

namespace FitnessArchitecture.Service.Interfaces
{
	public interface IExerciseToListService
	{
		public Task<IBaseResponse<ExerciseToList>> Create(ExerciseToList addedExercise);
		public Task<IBaseResponse<bool>> Delete(int ID);
	}
}