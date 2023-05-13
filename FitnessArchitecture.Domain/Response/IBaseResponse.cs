using System.Net;

namespace FitnessArchitecture.Domain.Response
{
	public interface IBaseResponse<T>
	{
		string Description { get; set; }
		HttpStatusCode StatusCode { get; set; }
		T Data { get; set; }
	}
}