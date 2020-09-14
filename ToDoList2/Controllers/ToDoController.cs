using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ToDoList2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _context;


        public ToDoController(ToDoContext context)
        {
            _context = context;

            //create an item if list is empty
            if (_context.ToDoItems.Count() == 0)
            {

                _context.ToDoItems.Add(new ToDoItem() { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(long id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);

            if (toDoItem == null)
                return NotFound();

            return toDoItem;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem toDoItem)
        {
            _context.ToDoItems.Add(toDoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToDoItem), new { id = toDoItem.Id, toDoItem});
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutToDoItem(long id, ToDoItem toDoItem)
        {
            if (id != toDoItem.Id)
                return BadRequest();

            _context.Entry(toDoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteToDoItem(long id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem == null)
                return NotFound();

            _context.ToDoItems.Remove(toDoItem);
            _context.SaveChanges();

            return NoContent();

            
        }
    }
}
