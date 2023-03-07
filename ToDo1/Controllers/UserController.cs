using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo1.Models;
using ToDo1.Data;

namespace ToDo1.Controllers
{
    public class UserController: Controller
    {
        private readonly AppDbContext _db;
        private readonly UserModel _user;
        public UserController(AppDbContext db, UserModel user) //Dependency injection
        {
            _db = db;
            _user = user;
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

        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            if (user == null)
            {
                return NotFound();
            }

            if (user.Email == null)
            {
                ModelState.AddModelError("Email", "Email not given");
                return View(user);
            }

            if (user.Password == null)
            {
                ModelState.AddModelError("Password", "Password not given");
                return View(user);
            }

            UserModel TempUser = _db.Users.FirstOrDefault(m => user.Email == m.Email);

            if (TempUser == null)
            {
                ModelState.AddModelError("Email", "Email not found");
                return View(user);
            }

            if (TempUser.Password.Equals(user.Password))
            {
                //Redirect
            }
            else
            {
                ModelState.AddModelError("Password", "Password is incorrect");
            }

            return View(user);
        }
    }
}
