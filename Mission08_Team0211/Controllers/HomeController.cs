using Microsoft.AspNetCore.Mvc;
using Mission08_Team0211.Models;
using System.Diagnostics;

namespace Mission08_Team0211.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepo _context;

        public HomeController(ITaskRepo temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            // Display all tasks that have not been completed
            var tasks = _context.AllTasks.Where(t => t.Completed != true).ToList();
            return View(tasks);
        }

        [HttpGet]

        public IActionResult Create()
        {

            ViewBag.Categories = _context.Categories.ToList();
            return View("AddTask", new AllTasks());
        }

        [HttpPost]
        public IActionResult Create(AllTasks task)
        {
            if (ModelState.IsValid)
            {
                _context.AddTask(task);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _context.Categories;
            return View("AddTask", task);
        }


        //[HttpPost]
        //public IActionResult TaskList()
        //{
        //    var tasks = _context.AllTasks
        //    .Where(t => t.Completed != true)
        //    .ToList();

        //    return View(tasks);
        //}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _context.AllTasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories;
            return View("AddTask", task); //
        }

        [HttpPost]
        public IActionResult Edit(AllTasks task)
        {
            if (ModelState.IsValid)
            {
                _context.EditTask(task);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _context.Categories;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _context.AllTasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            return View("Index");
        }

        [HttpPost, ActionName("Delete")] 
        public IActionResult DeleteConfirmed(int id)
        {
            _context.DeleteTask(id);
            return RedirectToAction("Index");
        }

    }
}


