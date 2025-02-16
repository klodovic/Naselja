using EntityFrameworkPaginateCore;
using FullStackTask_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace FullStackTask_API.Model
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly ApplicationDbContext _db;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }


        public async Task<List<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _db.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }


        public async Task<Page<T>> GetAllWithIncludesPageAsync(int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _db.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.PaginateAsync(pageNumber, pageSize);
        }



        public async Task<T?> GetSingleWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _db.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }



        public async Task<T?> GetAsync(int? id)
        {
            if (id.Equals(null))
            {
                return null;
            }

            return await _db.Set<T>().FindAsync(id);
        }


        public async Task CreateNewAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }


        public async Task UpdateAsync(T entity)
        {
             _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }


        public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }


        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
