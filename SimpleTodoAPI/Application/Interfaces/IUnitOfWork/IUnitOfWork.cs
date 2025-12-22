using SimpleTodoAPI.Application.Interfaces.Repositories;

namespace SimpleTodoAPI.Application.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class;

        Task<int> SaveAsync();
    }
}
