using Microsoft.AspNetCore.Mvc;
using Mission08_Team0211.Models;
using System.Diagnostics;

namespace Mission08_Team0211.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext _context;

        public HomeController(TaskContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            // Display all tasks that have not been completed
            var tasks = _context.Tasks.Where(t => t.Completed != true).ToList();
            return View(tasks);
        }

        [HttpGet]
        
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategories();
            //Access tasks
            var tasks = _context.AllTasks.ToList();
            return View("AddTask");
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = GetCategories();
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
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewBag.Categories = GetCategories();
            return View("Index", task);
        }

        [HttpPost]
        public IActionResult Edit(MyTasks task)
        {
            if (ModelState.IsValid)
            {
                _context.AllTasks.Update(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = GetCategories();
            return View("AddTask", task);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<string> GetCategories()
        {
            // Retrieve categories from the database
            var categories = _context.Categories.Select(c => c.CategoryName).ToList();
            return categories;
        }
    }
}
