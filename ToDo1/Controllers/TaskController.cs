using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo1.Models;
using ToDo1.Data;

namespace ToDo1.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _db;

        public TaskController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tasks = await _db.Tasks.ToListAsync();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                var result = _db.Add(task);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _db.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskModel task)
        {
            if (task == null)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(task);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return View();
        }
    }
}
