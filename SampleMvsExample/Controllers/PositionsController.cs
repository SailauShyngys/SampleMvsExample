using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleMvsExample.Persistence;
using SampleMvsExample.Models;

namespace Samp.Controllers
{
    public class PositionController : Controller
    {
        private readonly DataContext _context;

        public PositionController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Positions
                  .ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Position user = new Position();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Position position)
        {
            position.CreateId = DateTime.Now;
            position.ModifiedId = DateTime.Now;
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.Positions.FindAsync(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Position positions)
        {
            if (positions is null)
            {
                throw new ArgumentException(nameof(positions));
            }
            _context.Positions.Update(positions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var positions = await _context.Positions.FindAsync(id);
            var zo = _context.Users.FirstOrDefault(f => f.PositionId == positions.id);
            if (zo == null)
            {
                _context.Positions.Remove(positions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {

                return RedirectToAction("Error", "HomeController");
            }
        }
    }
}



