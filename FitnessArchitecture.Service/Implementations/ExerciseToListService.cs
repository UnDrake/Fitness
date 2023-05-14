using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessArchitecture.Service.Implementations
{
	public class ExerciseToListService : IExerciseToListService
	{
		private readonly IBaseRepository<Account> accountRepsitory;
		private readonly IBaseRepository<ExerciseToList> exerciseToListRepository;

		public ExerciseToListService(IBaseRepository<Account> accountRepsitory, 
			IBaseRepository<ExerciseToList> exerciseToListRepository)
		{
			this.accountRepsitory = accountRepsitory;
			this.exerciseToListRepository = exerciseToListRepository;
		}

		public async Task<IBaseResponse<ExerciseToList>> Create(ExerciseToList exerciseToList)
		{
			try
			{
				var account = await accountRepsitory.GetAll().Include(a => a.exerciseList)
					.FirstOrDefaultAsync(a => a.accountEmail == exerciseToList.addedAccountEmail);

				if (account == null)
				{
					return new BaseResponse<ExerciseToList>()
					{
						Description = "No account found with this email",
                        StatusCode = System.Net.HttpStatusCode.NotFound,
					};
				}

				var exercise = new ExerciseToList()
				{
					exerciseListID = exerciseToList.exerciseListID,
					exerciseID = exerciseToList.exerciseID,
					addedAccountEmail = exerciseToList.addedAccountEmail,
					exerciseList = account.exerciseList,
				};

				await exerciseToListRepository.Create(exercise);

				return new BaseResponse<ExerciseToList>()
				{
					Data = exercise,
					Description = "Exercise successfully added",
					StatusCode = System.Net.HttpStatusCode.OK,
				};

			}
			catch (Exception ex)
			{
				return new BaseResponse<ExerciseToList>()
				{
					Description = ex.Message,
					StatusCode = System.Net.HttpStatusCode.InternalServerError,
				};
			}
		}

		public async Task<IBaseResponse<bool>> Delete(int ID)
		{
			try
			{
				var exercise = await exerciseToListRepository.GetAll().Include(e => e.exerciseList)
					.FirstOrDefaultAsync(e => e.exerciseID == ID);

				if (exercise == null)
				{
					return new BaseResponse<bool>()
					{
						Description = "Exercise not found",
						StatusCode = System.Net.HttpStatusCode.NoContent,
					};
				}

				await exerciseToListRepository.Delete(exercise);

				return new BaseResponse<bool>()
				{
					Data = true,
					Description = "Exercise successfully deleted",
					StatusCode = System.Net.HttpStatusCode.OK,
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>()
				{ 
					Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
			}
		}
	}
}