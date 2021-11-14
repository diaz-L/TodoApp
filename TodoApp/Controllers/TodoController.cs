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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todo = _ctx.Todos.Find(id);

            if (todo is null)
            {
                ViewBag.NotFound = true;
                return RedirectToAction("Index", "Home");
            }
            
            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                _ctx.Todos.Update(todo);
                _ctx.SaveChanges();
                
                return RedirectToAction("Index", "Home");
            }

            return View(todo);
        }
        
    }
}