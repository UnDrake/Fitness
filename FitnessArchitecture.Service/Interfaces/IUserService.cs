using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.User;

namespace FitnessArchitecture.Service.Interfaces
{
    public interface IUserService
	{
        Task<BaseResponse<UserProfileViewModel>> GetUser(string accountEmail);
        Task<BaseResponse<bool>> UpdateUser(UserViewModel user);
    }
}