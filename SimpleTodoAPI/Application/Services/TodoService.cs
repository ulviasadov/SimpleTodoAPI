using SimpleTodoAPI.Application.DTOs;
using SimpleTodoAPI.Application.Interfaces.IUnitOfWork;
using SimpleTodoAPI.Application.Interfaces.Services;
using SimpleTodoAPI.Domain.Entities;

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

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _uow.GetRepository<Todo>().GetAllAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            var exist = await _uow.GetRepository<Todo>().GetByIdAsync(id);

            if (exist == null) return null;

            return exist;
        }
    }
}
