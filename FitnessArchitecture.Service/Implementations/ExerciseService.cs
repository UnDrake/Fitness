using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using FitnessArchitecture.Domain.ViewModels.Exercise;
using FitnessArchitecture.Domain.ViewModels.Sleep;

namespace FitnessArchitecture.Service.Implementations
{
	public class ExerciseService : IExerciseService
    {
        private readonly IBaseRepository<Exercise> exerciseRepository;
        public ExerciseService(IBaseRepository<Exercise> exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }

		public async Task<IBaseResponse<ExerciseViewModel>> GetExercise(int ID)
		{
			try
			{
				var exercise = await exerciseRepository.GetAll().Select(e => new ExerciseViewModel()
                {
                    exerciseID = e.exerciseID,
					exerciseName = e.exerciseName,
					exerciseCalories = e.exerciseCalories,
					exerciseLongDescription = e.exerciseLongDescription,
					exerciseImg = e.exerciseImg,
                }).FirstOrDefaultAsync(e => e.exerciseID == ID);

				if (exercise == null)
				{
					return new BaseResponse<ExerciseViewModel>()
					{
						Description = "Exercise not found",
                        StatusCode = System.Net.HttpStatusCode.NoContent,
                    };
				}

				return new BaseResponse<ExerciseViewModel>()
				{
					Data = exercise,
					Description = "Exercise successfully found",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
			}
			catch (Exception ex)
			{
				return new BaseResponse<ExerciseViewModel>()
				{
					Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
			}
		}

		public IBaseResponse<List<ExerciseShortViewModel>> GetExercises()
		{
			try
			{
				var exercises = exerciseRepository.GetAll().Select(e => new ExerciseShortViewModel()
                {
                    exerciseID = e.exerciseID,
                    exerciseName = e.exerciseName,
                    exerciseCalories = e.exerciseCalories,
                    exerciseImg = e.exerciseImg,
                }).ToList();

				if (!exercises.Any())
				{
					return new BaseResponse<List<ExerciseShortViewModel>>()
					{
						Description = "Exercises not found",
                        StatusCode = System.Net.HttpStatusCode.NoContent,
                    };
				}

				return new BaseResponse<List<ExerciseShortViewModel>>()
				{
					Data = exercises,
					Description = "Exercises successfully found",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
			}
			catch (Exception ex)
			{
				return new BaseResponse<List<ExerciseShortViewModel>>()
				{
					Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
			}
		}
	}
}