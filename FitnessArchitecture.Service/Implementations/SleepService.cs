using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using FitnessArchitecture.Domain.ViewModels.Sleep;

namespace FitnessArchitecture.Service.Implementations
{
	public class SleepService : ISleepService
	{
		private readonly IBaseRepository<Sleep> sleepRepository;

		public SleepService(IBaseRepository<Sleep> sleepRepository)
		{
			this.sleepRepository = sleepRepository;
		}

		public async Task<IBaseResponse<SleepViewModel>> GetSleep(string accountEmail)
		{
			try
			{
				var sleep = await sleepRepository.GetAll()
					.Select(x => new SleepViewModel()
					{
						sleepAccountEmail = x.sleepAccountEmail,
						sleepTime = x.sleepTime,
					}).FirstOrDefaultAsync(x => x.sleepAccountEmail == accountEmail);

				return new BaseResponse<SleepViewModel>()
				{
					Data = sleep,
					Description = "Sleep successfully get",
					StatusCode = System.Net.HttpStatusCode.OK,
				};
			}
			catch(Exception ex)
			{
				return new BaseResponse<SleepViewModel>()
				{
					Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
			}
		}

		public async Task<IBaseResponse<SleepViewModel>> Update(SleepViewModel updateSleep)
		{
			try
			{
				var sleep = await sleepRepository.GetAll().FirstOrDefaultAsync(
					s => s.sleepAccountEmail == updateSleep.sleepAccountEmail);
				sleep.sleepTime = updateSleep.sleepTime;
				await sleepRepository.Update(sleep);

				return new BaseResponse<SleepViewModel>()
				{
					Data = new SleepViewModel()
					{
						sleepAccountEmail = sleep.sleepAccountEmail,
						sleepTime = sleep.sleepTime,
					},
					Description = "Sleep successfully update",
					StatusCode = System.Net.HttpStatusCode.OK,
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<SleepViewModel>()
				{
					Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
			}
		}
	}
}