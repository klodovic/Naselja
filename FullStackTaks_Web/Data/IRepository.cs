namespace FullStackTask_Web.Service
{
    public interface IRepository<T> where T : class
    {
        Task<TResponse> CreateAsync<TResponse>(T entity);
        Task<TResponse> DeleteAsync<TResponse>(int id);
        Task<TResponse> GetAllAsync<TResponse>();
        Task<TResponse> GetAsync<TResponse>(int id);
        Task<TResponse> UpdateAsync<TResponse>(int id, T entity);
    }
}
