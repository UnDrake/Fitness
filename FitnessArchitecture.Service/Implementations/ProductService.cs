using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.Product;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FitnessArchitecture.Service.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IBaseRepository<Product> productRepository;
		public ProductService(IBaseRepository<Product> productRepository)
		{
			this.productRepository = productRepository;
		}

		public async Task<IBaseResponse<ProductViewModel>> GetProduct(int ID)
		{
			try
			{
				var product = await productRepository.GetAll().Select(p => new ProductViewModel()
                {
                    productID = p.productID,
					productName = p.productName,
					productCalories = p.productCalories,
					productWeight = p.productWeight,
					productCarbs = p.productCarbs,
					productProteins = p.productProteins,
					productFats = p.productFats,
					productImg = p.productImg,
                }).FirstOrDefaultAsync(p => p.productID == ID);

				if (product == null)
				{
					return new BaseResponse<ProductViewModel>()
					{
						Description = "Product not found",
						StatusCode = System.Net.HttpStatusCode.NoContent,
					};
				}

				return new BaseResponse<ProductViewModel> 
				{ 
					Data = product,
					Description = "Product susccessfully get",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
			}
			catch (Exception ex)
			{
				return new BaseResponse<ProductViewModel>
				{
					Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
			}
		}

		public IBaseResponse<List<ProductShortViewModel>> GetProducts()
		{
			try
			{
				var products = productRepository.GetAll().Select(p => new ProductShortViewModel()
                {
                    productID = p.productID,
                    productName = p.productName,
                    productCalories = p.productCalories,
                    productImg = p.productImg,
                }).ToList();

				if (!products.Any())
				{
					return new BaseResponse<List<ProductShortViewModel>>()
					{
						Description = "Products not found",
						StatusCode= System.Net.HttpStatusCode.NoContent,
					};
				}

				return new BaseResponse<List<ProductShortViewModel>>()
				{
					Data = products,
					Description = "Products successfully get",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
			}
			catch (Exception ex)
			{
				return new BaseResponse<List<ProductShortViewModel>>
				{
                    Description = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
			}
		}
	}
}