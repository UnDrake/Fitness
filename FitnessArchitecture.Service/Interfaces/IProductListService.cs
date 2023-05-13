using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.Product;

namespace FitnessArchitecture.Service.Interfaces
{
	public interface IProductListService
	{
		public Task<IBaseResponse<List<ProductShortViewModel>>> GetProducts(string accountEmail);
	}
}
