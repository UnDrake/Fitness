using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.Exercise;

namespace FitnessArchitecture.Service.Interfaces
{
	public interface IExerciseService
	{
		Task<IBaseResponse<ExerciseViewModel>> GetExercise(int ID);
		IBaseResponse<List<ExerciseShortViewModel>> GetExercises();
	}
}