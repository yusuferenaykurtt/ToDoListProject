using Microsoft.AspNetCore.Mvc;
using ToDoListProject.Context;
using ToDoListProject.Entity;

namespace ToDoListProject.Controllers
{
    public class ToDoController : Controller
    {

        private readonly ApplicationDbContext _context=new ApplicationDbContext();
        public IActionResult Index()
        {

            var todos=_context.toDos.ToList();

            return View(todos);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Create(ToDo toDo)
        {
            _context.toDos.Add(toDo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            var todos = _context.toDos.Find(id);

            if (todos != null)
            {

                _context.toDos.Remove(todos);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult ToggleCompleted(int id)
        {

            var todos = _context.toDos.Find(id);

            if (todos != null)
            {
                todos.IsCompleted = !todos.IsCompleted;

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todos= _context.toDos.Find(id);

            if(todos == null)
            {
                return NotFound();
            }
            return View(todos);
        }

        [HttpPost]

        public IActionResult Edit(ToDo toDo)
        {
            var todos=_context.toDos.Find(toDo.Id);

            if(todos != null)
            {
                todos.Title= toDo.Title;

                todos.IsCompleted= toDo.IsCompleted;

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        }
    }
