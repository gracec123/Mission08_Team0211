using Microsoft.AspNetCore.Mvc;
using Mission08_Team0211.Models;

namespace Mission08_Team0211.Controllers;

public class HomeController : Controller
{
    private readonly ITaskRepo _context;

    // Controller responsible for handling actions related to tasks
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


    // Displays form to create a new task
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.Title = "Create Task";

        return View("AddTask", new AllTasks());
    }

    // Handles creation of a new task
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

    // Displays form to edit an existing task
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _context.AllTasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null) return NotFound();

        ViewBag.Categories = _context.Categories;
        ViewBag.Title = "Edit Task";
        return View("AddTask", task); //
    }

    // Handles editing an existing task
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

    // Displays confirmation page for deleting a task
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var task = _context.AllTasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null) return NotFound();


        return View(task);
    }

    // Handles deletion of a task
    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _context.DeleteTask(id);
        return RedirectToAction("Index");
    }
}