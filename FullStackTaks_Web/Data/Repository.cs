using FullStackTask_Web.Models;
using Microsoft.Extensions.Configuration;

namespace FullStackTask_Web.Service
{
    public class Repository<T> : BaseService, IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly string apiUrl;
        private readonly string route; // Dinamička ruta

        public Repository(IHttpClientFactory httpClient, IConfiguration configuration, string entityRoute) : base(httpClient)
        {
            _httpClient = httpClient;
            apiUrl = configuration.GetValue<string>("ServiceUrls:ApiUrl");
            route = entityRoute; // Npr. "api/naselje" ili "api/drzava"
        }

        public Task<TResponse> CreateAsync<TResponse>(T entity)
        {
            return SendAsync<TResponse>(new ApiRequest()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = entity,
                Url = $"{apiUrl}/{route}"
            });
        }

        public Task<TResponse> DeleteAsync<TResponse>(int id)
        {
            return SendAsync<TResponse>(new ApiRequest()
            {
                ApiType = Utility.SD.ApiType.DELETE,
                Url = $"{apiUrl}/{route}/{id}"
            });
        }

        public Task<TResponse> GetAllAsync<TResponse>()
        {
            return SendAsync<TResponse>(new ApiRequest()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = $"{apiUrl}/{route}"
            });
        }

        public Task<TResponse> GetAsync<TResponse>(int id)
        {
            return SendAsync<TResponse>(new ApiRequest()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = $"{apiUrl}/{route}/{id}"
            });
        }

        public Task<TResponse> UpdateAsync<TResponse>(int id, T entity)
        {
            return SendAsync<TResponse>(new ApiRequest()
            {
                ApiType = Utility.SD.ApiType.PUT,
                Data = entity,
                Url = $"{apiUrl}/{route}/{id}"
            });
        }
    }
}
