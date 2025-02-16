using EntityFrameworkPaginateCore;
using System.Linq.Expressions;

namespace FullStackTask_API.Model
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
        Task<Page<T>> GetAllWithIncludesPageAsync(int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes);

        Task<T?> GetSingleWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<T?> GetAsync(int? id);

        Task CreateNewAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
        
    }
}
