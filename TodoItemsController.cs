using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TodoItemsController(AppDbContext db) => _db = db;

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAll()
        {
            return await _db.TodoItems.AsNoTracking().OrderBy(t => t.Id).ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TodoItem>> GetById(int id)
        {
            var item = await _db.TodoItems.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create([FromBody] TodoItem item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _db.TodoItems.Add(item);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoItem updated)
        {
            if (id != updated.Id) return BadRequest("ID mismatch.");
            if (!await _db.TodoItems.AnyAsync(t => t.Id == id)) return NotFound();

            _db.Entry(updated).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // PATCH: api/TodoItems/5/done
        [HttpPatch("{id:int}/done")]
        public async Task<IActionResult> MarkDone(int id)
        {
            var item = await _db.TodoItems.FindAsync(id);
            if (item == null) return NotFound();
            item.IsDone = true;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.TodoItems.FindAsync(id);
            if (item == null) return NotFound();
            _db.TodoItems.Remove(item);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}