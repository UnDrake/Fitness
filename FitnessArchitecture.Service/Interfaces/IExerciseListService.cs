using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.Exercise;

namespace FitnessArchitecture.Service.Interfaces
{
	public interface IExerciseListService
	{
		public Task<IBaseResponse<List<ExerciseShortViewModel>>> GetExercises(string accountEmail);
	}
}