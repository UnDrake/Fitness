using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.Exercise;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessArchitecture.Service.Implementations
{
	public class ExerciseListService : IExerciseListService
	{
		private readonly IBaseRepository<Account> accountRepository;
		private readonly IBaseRepository<Exercise> exerciseRepository;

		public ExerciseListService(IBaseRepository<Account> accountRepository, IBaseRepository<Exercise> exerciseRepository)
		{
			this.accountRepository = accountRepository;
			this.exerciseRepository = exerciseRepository;
		}

		public async Task<IBaseResponse<List<ExerciseShortViewModel>>> GetExercises(string accountEmail)
		{
			try
			{
				var account = await accountRepository.GetAll().Include(a => a.exerciseList)
					.ThenInclude(a => a.addedExercises).FirstOrDefaultAsync(a => a.accountEmail == accountEmail);

				if (account == null)
				{
					return new BaseResponse<List<ExerciseShortViewModel>>
					{
						Description = "No account found with this email",
						StatusCode = System.Net.HttpStatusCode.NotFound,
					};
				}

				var addedExercises = account.exerciseList?.addedExercises;

                List<ExerciseShortViewModel> exercises = new List<ExerciseShortViewModel>();
                foreach (var ex in addedExercises)
				{
                    var exercise = exerciseRepository.GetAll().Select(e => new ExerciseShortViewModel()
                    {
                        exerciseID = e.exerciseID,
                        exerciseName = e.exerciseName,
                        exerciseCalories = e.exerciseCalories,
                        exerciseImg = e.exerciseImg,
                    }).FirstOrDefault(e => e.exerciseID == ex.exerciseID);

                    if (exercise != null)
                    {
                        exercises.Add(exercise);
                    }
                }

                return new BaseResponse<List<ExerciseShortViewModel>>()
				{
					Data = exercises,
					Description = "Exercises from the list have been successfully received",
					StatusCode = System.Net.HttpStatusCode.OK,
				};

			}
			catch(Exception ex)
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