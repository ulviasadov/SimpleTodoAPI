using SimpleTodoAPI.Application.Interfaces.IUnitOfWork;
using SimpleTodoAPI.Application.Interfaces.Repositories;
using SimpleTodoAPI.Infrastructure.Data;
using SimpleTodoAPI.Infrastructure.Repositories;

namespace SimpleTodoAPI.Application.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!_repositories.ContainsKey(type))
            {
                var repoInstance = new GenericRepository<T>(_dbContext);
                _repositories[type] = repoInstance;
            }

            return (IGenericRepository<T>)_repositories[type];
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
