using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Helpers;
using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.User;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FitnessArchitecture.Service.Implementations
{
	public class AccountService : IAccountService
	{
		private readonly IBaseRepository<Account> accountRepository;
		private readonly IBaseRepository<User> userRepository;
		private readonly IBaseRepository<ProductList> productListRepository;
		private readonly IBaseRepository<ExerciseList> exerciseListRepository;
		private readonly IBaseRepository<Sleep> sleepRepository;

		public AccountService(IBaseRepository<Account> accountRepository, IBaseRepository<User> userRepository,
			IBaseRepository<ProductList> productListRepository, IBaseRepository<ExerciseList> exerciseListRepository,
			IBaseRepository<Sleep> sleepRepository)
		{
			this.accountRepository = accountRepository;
			this.userRepository = userRepository;
			this.productListRepository = productListRepository;
			this.exerciseListRepository = exerciseListRepository;
			this.sleepRepository = sleepRepository;
		}


		public async Task<IBaseResponse<ClaimsIdentity>> Register(AccountRegisterViewModel registerAccount)
		{
			try
			{
				var account = await accountRepository.GetAll().FirstOrDefaultAsync(
					a => a.accountEmail == registerAccount.accountEmail);

				if (account != null)
				{
					return new BaseResponse<ClaimsIdentity>
					{
						Description = "An account with this email already exists",
                        StatusCode = System.Net.HttpStatusCode.Conflict,
                    };
				}

				account = new Account()
				{
					accountEmail = registerAccount.accountEmail,
					accountPassword = HashPasswordHelper.HashPassoword(registerAccount.accountPassword),
				};

				await accountRepository.Create(account);

                var user = new User()
                {
                    userName = string.Empty,
                    userAge = 0,
                    userHeight = 0,
                    userWeight = 0,
                    userGender = 0,
                    userActivity = 0,
                    userNorm = 0,
                    accountID = account.accountID,
                };

				var productList = new ProductList()
				{
					accountID = account.accountID,
				};

				var exerciseList = new ExerciseList()
				{
					accountID = account.accountID,
				};

				var sleep = new Sleep()
				{
					accountID = account.accountID,
                    sleepAccountEmail = account.accountEmail,
                };

				await userRepository.Create(user);
				await productListRepository.Create(productList);
				await exerciseListRepository.Create(exerciseList);
				await sleepRepository.Create(sleep);

				var confirmedAccount = Authenticate(account);

				return new BaseResponse<ClaimsIdentity>
				{
					Data = confirmedAccount,
					Description = "Account created successfully",
					StatusCode = System.Net.HttpStatusCode.OK,
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<ClaimsIdentity>()
				{
					Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
			}
		}


		public async Task<IBaseResponse<ClaimsIdentity>> Login(AccountLoginViewModel loginAccount)
		{
			try
			{
				var account = await accountRepository.GetAll().FirstOrDefaultAsync(
					a => a.accountEmail == loginAccount.accountEmail);

				if (account == null)
				{
					return new BaseResponse<ClaimsIdentity>
					{
						Description = "No account found with this email",
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                    };
				}

				if (account.accountPassword != HashPasswordHelper.HashPassoword(loginAccount.accountPassword))
				{
					return new BaseResponse<ClaimsIdentity>
					{
						Description = "Incorrect password",
                        StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    };
				}

				var confirmedAccount = Authenticate(account);

				return new BaseResponse<ClaimsIdentity>()
				{
					Data = confirmedAccount,
					Description = "Login successful",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
			}
			catch (Exception ex)
			{
				return new BaseResponse<ClaimsIdentity>
				{
					Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
			}
		}


		private ClaimsIdentity Authenticate(Account account)
		{
            var claims = new List<Claim>
			{ 
				new Claim(ClaimTypes.Name, account.accountEmail),
				new Claim ("ID", account.accountID.ToString()),
            };
			return new ClaimsIdentity(claims, "Cookies");
		}


		public async Task<IBaseResponse<bool>> DeleteAccount(int ID)
		{
			try
			{
				var account = await accountRepository.GetAll().FirstOrDefaultAsync(a => a.accountID == ID);

				if (account == null)
				{
					return new BaseResponse<bool>()
					{
						Description = "No account found with this email",
						StatusCode = System.Net.HttpStatusCode.Unauthorized,
					};
				}

				await accountRepository.Delete(account);

				return new BaseResponse<bool>()
				{
					Data = true,
					Description = "Account successfully deleted",
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