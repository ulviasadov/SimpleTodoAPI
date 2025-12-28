using Microsoft.AspNetCore.Mvc;
using SimpleTodoAPI.Application.DTOs;
using SimpleTodoAPI.Application.Interfaces.Services;

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
        public async Task<IActionResult> GetAll([FromQuery]string? search)
        {
            return Ok(await _service.GetAllAsync(search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TodoCreateDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(dto);

            return Ok(await _service.AddAsync(dto));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteAsync(id);
        }

        [HttpPut]
        public async Task Update(TodoUpdateDto dto)
        {
            await _service.UpdateAsync(dto);
        }
    }
}
