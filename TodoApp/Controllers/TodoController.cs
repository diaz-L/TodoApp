using Microsoft.AspNetCore.Mvc;
using TodoApp.Entities;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private TodoContext _ctx;

        public TodoController(TodoContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new TodoItem());
        }

        [HttpPost]
        public IActionResult Add(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                _ctx.Todos.Add(new TodoItem { Text = todo.Text});
                _ctx.SaveChanges();
                
                return RedirectToAction("Index", "Home");
            }
            
            return View(todo);
        }
    }
}