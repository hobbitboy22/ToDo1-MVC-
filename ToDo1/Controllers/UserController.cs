using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo1.Models;
using ToDo1.Data;

namespace ToDo1.Controllers
{
    public class UserController: Controller
    {
        private readonly AppDbContext _db;
        public UserController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(UserModel user)
        {
            if (user == null)
            {
                return NotFound();
            }

            user.Id = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }

            return View(user);
        }
    }
}
