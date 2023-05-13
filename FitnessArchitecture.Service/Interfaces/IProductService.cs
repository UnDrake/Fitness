using FitnessArchitecture.Domain.Response;
using FitnessArchitecture.Domain.ViewModels.Product;

namespace FitnessArchitecture.Service.Interfaces
{
	public interface IProductService
	{
		Task<IBaseResponse<ProductViewModel>> GetProduct(int ID);
		IBaseResponse<List<ProductShortViewModel>> GetProducts();
	}
}