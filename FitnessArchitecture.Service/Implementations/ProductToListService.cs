using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessArchitecture.Service.Implementations
{
	public class ProductToListService : IProductToListService
	{
		private readonly IBaseRepository<Account> accountRepository;
		private readonly IBaseRepository<ProductToList> productToListRepository;

		public ProductToListService(IBaseRepository<Account> accountRepository, 
			IBaseRepository<ProductToList> productToListRepository)
		{
			this.accountRepository = accountRepository;
			this.productToListRepository = productToListRepository;
		}


		public async Task<IBaseResponse<ProductToList>> Create(ProductToList addedProduct)
		{
			try
			{
				var account = await accountRepository.GetAll().Include(p => p.productList)
					.FirstOrDefaultAsync(a => a.accountEmail == addedProduct.addedAccountEmail);

				if (account == null)
				{
					return new BaseResponse<ProductToList>()
					{
						Description = "No account found with this email",
						StatusCode = System.Net.HttpStatusCode.NotFound,
					};
				}

				var product = new ProductToList()
				{
					productListID = addedProduct.productListID,
					productID = addedProduct.productID,
					addedAccountEmail = addedProduct.addedAccountEmail,
					productList = account.productList,
				};

				await productToListRepository.Create(product);

				return new BaseResponse<ProductToList>()
				{
					Data = product,
					Description = "Product successfully added",
					StatusCode = System.Net.HttpStatusCode.OK,
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<ProductToList>()
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
				var product = await productToListRepository.GetAll().Include(p => p.productList)
					.FirstOrDefaultAsync(p => p.productID == ID);

				if (product == null)
				{
					return new BaseResponse<bool>()
					{
						Description = "Product not found",
						StatusCode = System.Net.HttpStatusCode.NoContent,
					};
				}

				await productToListRepository.Delete(product);

				return new BaseResponse<bool>()
				{
					Data = true,
					Description = "Product successfully deleted",
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