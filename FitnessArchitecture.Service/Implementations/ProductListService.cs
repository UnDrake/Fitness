using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.Exercise;
using FitnessArchitecture.Domain.ViewModels.Product;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessArchitecture.Service.Implementations
{
	public class ProductListService : IProductListService
	{
		private readonly IBaseRepository<Account> accountRepository;
		private readonly IBaseRepository<Product> productRepository;

		public ProductListService(IBaseRepository<Account> accountRepository, IBaseRepository<Product> productRepository)
		{
			this.accountRepository = accountRepository;
			this.productRepository = productRepository;
		}


		public async Task<IBaseResponse<List<ProductShortViewModel>>> GetProducts(string accountEmail)
		{
			try
			{
				var account = await accountRepository.GetAll().Include(a => a.productList)
					.ThenInclude(a => a.addedProducts).FirstOrDefaultAsync(a => a.accountEmail == accountEmail);

				if (account == null)
				{
					return new BaseResponse<List<ProductShortViewModel>>()
					{
						Description = "No account found with this email",
						StatusCode = System.Net.HttpStatusCode.NotFound
					};
				}

				var addedProducts = account.productList?.addedProducts;

				List<ProductShortViewModel> response = new List<ProductShortViewModel>();
				foreach (var pr in addedProducts)
				{
					var product = productRepository.GetAll().Select(p => new ProductShortViewModel()
                    {
                        productID = p.productID,
						productName = p.productName,
						productCalories = p.productCalories,
						productImg = p.productImg,
                    }).FirstOrDefault(p => p.productID == pr.productID);
					if (product != null)
					{
                        response.Add(product);
					}
				}

				return new BaseResponse<List<ProductShortViewModel>>()
				{
					Data = response,
					Description = "Products from the list have been successfully received",
					StatusCode = System.Net.HttpStatusCode.OK,
				};
			}

			catch (Exception ex)
			{
				return new BaseResponse<List<ProductShortViewModel>>
				{
					Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
			}
		}
	}
}
