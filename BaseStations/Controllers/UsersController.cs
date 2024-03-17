using BaseStations.Context;
using BaseStations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseStations.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users/Add
        public async Task<IActionResult> AddUsers()
        {
            var users = await _context.Users.ToListAsync();            

            return View(users);
        }

        // POST: Users/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(User userModel)
        {
            if (ModelState.IsValid)
            {
                // Проверка, существует ли пользователь с таким логином
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Login == userModel.Login);
                if (existingUser != null)
                {
                    var users = await _context.Users.ToListAsync(); // Получаем полный список пользователей
                    ModelState.AddModelError("Login", "Пользователь с таким логином уже существует.");
                    return View("AddUsers", users);
                }

                _context.Add(userModel);
                await _context.SaveChangesAsync();

                // Возвращаем представление с новым списком пользователей
                return RedirectToAction(nameof(AddUsers));
            }
            
            // Если модель недействительна, возвращаем представление с текущей моделью
            var currentUsers = await _context.Users.ToListAsync();
            return View("AddUsers", currentUsers);
        }

        // POST: Users/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AddUsers));
        }
    }
}
