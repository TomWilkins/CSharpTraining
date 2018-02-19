using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {

        // Readonly can be set in the constructor
        private readonly TodoContext _context;

        // Constructor using Dependency Injection to inject the database context. 
        public TodoController(TodoContext context){
            _context = context;

            if(_context.TodoItems.Count() == 0){
                _context.TodoItems.Add(new TodoItem { Name = "Item1"});
                _context.SaveChanges();
            }
        }

        // MVC automatically serialises the object to JSON
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(){
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id){
            var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if(item == null){
                return NotFound();
            }
            return new ObjectResult(item);
        }


        /// <summary>
        /// Create a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo
        ///     {
        ///         "id":1,
        ///         "name": "Item1",
        ///         "isComplete": true
        ///     }
        /// </remarks>
        /// <returns>A newly-created TodoItem</returns>
        /// <param name="item"></param>
        /// <response code="201">Returns the newly-created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(typeof(TodoItem),201)]
        [ProducesResponseType(typeof(TodoItem), 400)]
        public IActionResult Create([FromBody] TodoItem item){ // FromBody tells MVC to get the value from the body of the request
            
            if(item == null){
                return BadRequest();
            }

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item); // CreatedAtRoute returns a 201 response
        }

        // Update
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item){
            
            if(item == null || item.Id != id){
                return BadRequest();
            }

            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if(todo == null){
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();

        }


        /// <summary>
        /// Delete the specified TodoItem.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id){
            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);

            if (todo == null)
                return NotFound();

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
