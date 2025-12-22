using Microsoft.AspNetCore.Mvc;
using SimpleTodoAPI.Application.DTOs;
using SimpleTodoAPI.Application.Interfaces.Services;
using SimpleTodoAPI.Domain.Entities;

namespace SimpleTodoAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoCreateDto dto)
        {
            return Ok(await _service.AddAsync(dto));
        }
    }
}
