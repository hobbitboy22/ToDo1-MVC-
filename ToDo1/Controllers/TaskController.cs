using Microsoft.AspNetCore.Mvc;
using ToDo1.Models;

namespace ToDo1.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TaskModel task)
        {
            return View();      
        }
    }
}
