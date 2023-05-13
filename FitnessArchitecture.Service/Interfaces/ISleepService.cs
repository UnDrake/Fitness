using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.Sleep;

namespace FitnessArchitecture.Service.Interfaces
{
	public interface ISleepService
	{
		public Task<IBaseResponse<SleepViewModel>> GetSleep(string accountEmail);
		public Task<IBaseResponse<SleepViewModel>> Update(SleepViewModel updateSleep);
	}
}
