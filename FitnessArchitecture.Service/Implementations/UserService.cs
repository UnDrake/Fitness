using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.User;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FitnessArchitecture.Service.Implementations
{
	public class UserService : IUserService
	{
		private readonly IBaseRepository<User> userRepository;

		public UserService(IBaseRepository<User> userRepository)
		{
			this.userRepository = userRepository;
		}

		public async Task<BaseResponse<UserProfileViewModel>> GetUser(string accountEmail)
		{
			try
			{
				var user = await userRepository.GetAll()
					.Select(a => new UserProfileViewModel()
					{
						userID = a.userID,
						userActivity = a.userActivity,
						userAge = a.userAge,
						userGender = a.userGender,
						userHeight = a.userHeight,
						userName = a.userName,
						userNorm = a.userNorm,
						userWeight = a.userWeight,
						userEmail = a.account.accountEmail,
					})
					.FirstOrDefaultAsync(a => a.userEmail == accountEmail);

				return new BaseResponse<UserProfileViewModel>
				{
					Data = user,
					Description = "User successful get",
					StatusCode = System.Net.HttpStatusCode.OK,
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<UserProfileViewModel>
				{
					Description = ex.Message,
					StatusCode = System.Net.HttpStatusCode.InternalServerError,
				};
			}
		}

		public async Task<BaseResponse<bool>> UpdateUser(UserViewModel updateUser)
		{
			try
			{
				var user = await userRepository.GetAll().FirstOrDefaultAsync(u => u.userID == updateUser.userID);
				user.userWeight = updateUser.userWeight;
				user.userName = updateUser.userName;
				user.userNorm = updateUser.userNorm;
				user.userHeight = updateUser.userHeight;
				user.userGender = updateUser.userGender;
				user.userAge = updateUser.userAge;
				user.userActivity = updateUser.userActivity;
				user.NormCalculation();
                await userRepository.Update(user);

				return new BaseResponse<bool>()
				{
					Data = true,
					Description = "User successful update",
                    StatusCode = System.Net.HttpStatusCode.OK
                };
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>()
				{
					Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
			}
		}
	}
}