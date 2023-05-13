using System.Net;

namespace FitnessArchitecture.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
	{
		public string Description { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}