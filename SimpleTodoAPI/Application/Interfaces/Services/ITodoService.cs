using SimpleTodoAPI.Application.DTOs;
using SimpleTodoAPI.Domain.Entities;

namespace SimpleTodoAPI.Application.Interfaces.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task<TodoCreateDto> AddAsync(TodoCreateDto entity);
        Task DeleteAsync(int id);
    }
}
