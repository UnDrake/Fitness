using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.Response;

namespace FitnessArchitecture.Service.Interfaces
{
	public interface IProductToListService
	{
		public Task<IBaseResponse<ProductToList>> Create(ProductToList addedProduct);
		public Task<IBaseResponse<bool>> Delete(int ID);
	}
}