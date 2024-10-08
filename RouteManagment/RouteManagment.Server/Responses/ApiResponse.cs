using RouteManagment.Core.Entities;

namespace RouteManagment.Server.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public ApiResponse(Transport result)
        {
        }

        public T Data { get; set; }
    }
}