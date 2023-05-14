using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.User;
using System.Security.Claims;

namespace FitnessArchitecture.Service.Interfaces
{
	public interface IAccountService
	{
		Task<IBaseResponse<ClaimsIdentity>> Register(AccountRegisterViewModel registerAccount);
		Task<IBaseResponse<ClaimsIdentity>> Login(AccountLoginViewModel loginAccount);
		Task<IBaseResponse<bool>> DeleteAccount(int ID);
	}
}