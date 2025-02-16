using FullStackTask_Web.Model;
using FullStackTask_Web.Models;

namespace FullStackTask_Web.Service
{
    public interface IBaseService
    {
        ApiResponse responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
