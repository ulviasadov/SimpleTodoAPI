using SimpleTodoAPI.Application.DTOs;
using SimpleTodoAPI.Application.Interfaces.IUnitOfWork;
using SimpleTodoAPI.Application.Interfaces.Services;
using SimpleTodoAPI.Domain.Entities;
using System.Linq.Expressions;

namespace SimpleTodoAPI.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _uow;

        public TodoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TodoCreateDto> AddAsync(TodoCreateDto dto)
        {
            var entity = new Todo
            {
                Title = dto.Title,
                BodyText = dto.BodyText,
            };

            await _uow.GetRepository<Todo>().AddAsync(entity);
            await _uow.SaveAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await _uow.GetRepository<Todo>().GetByIdAsync(id);

            if (exist == null) throw new Exception("Not found!");

            _uow.GetRepository<Todo>().DeleteAsync(exist);
            await _uow.SaveAsync();
        }

        public async Task<List<Todo>> GetAllAsync(string? search)
        {
            Expression<Func<Todo, bool>>? filter = null;

            if (search != null)
            {
                filter = t => t.Title.Contains(search) || t.BodyText.Contains(search);
                return await _uow.GetRepository<Todo>().GetByFilter(filter);
            }

            return await _uow.GetRepository<Todo>().GetAllAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            var exist = await _uow.GetRepository<Todo>().GetByIdAsync(id);

            if (exist == null) return null;

            return exist;
        }

        public async Task UpdateAsync(TodoUpdateDto dto)
        {
            var todo = new Todo
            {
                Id = dto.Id,
                Title = dto.Title,
                BodyText = dto.BodyText,
            };

            _uow.GetRepository<Todo>().UpdateAsync(todo);
            await _uow.SaveAsync();
        }
    }
}
