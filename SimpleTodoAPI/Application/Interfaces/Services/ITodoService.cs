using SimpleTodoAPI.Application.DTOs;
using SimpleTodoAPI.Domain.Entities;
using System.Linq.Expressions;

namespace SimpleTodoAPI.Application.Interfaces.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllAsync(string? search);
        Task<Todo?> GetByIdAsync(int id);
        Task<TodoCreateDto> AddAsync(TodoCreateDto entity);
        Task UpdateAsync(TodoUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
