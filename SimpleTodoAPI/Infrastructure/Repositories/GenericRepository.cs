using Microsoft.EntityFrameworkCore;
using SimpleTodoAPI.Application.Interfaces.Repositories;
using SimpleTodoAPI.Infrastructure.Data;
using System.Linq.Expressions;

namespace SimpleTodoAPI.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where<T>(filter).ToListAsync();
        }

        public async void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
