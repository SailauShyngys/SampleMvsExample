using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleMvsExample.Models;
using SampleMvsExample.Persistence;

namespace SampleMvsExample.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        //Контроллер, который возвращает список пользователей
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.Include(i => i.Position).ToListAsync();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> PositionIndex(int id)
        {
            var users = await _context.Positions.Include(i => i.Title).ToListAsync();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            User user = new();
            var positions = await _context.Positions.ToListAsync();
            ViewBag.Positions = positions;
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            user.CreateId = DateTime.Now;
            user.ModifiedId = DateTime.Now;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            User? user = await _context.Users.FindAsync(id);
            var positions = await _context.Positions.ToListAsync();
            ViewBag.Positions = positions;
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if(user is null)
                throw new ArgumentException(nameof(user));
            user.ModifiedId = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                throw new ArgumentException(nameof(user));
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
