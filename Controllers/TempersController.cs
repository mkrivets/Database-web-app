using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cats;

namespace Cats.Controllers
{
    public class TempersController : Controller
    {
        private readonly DBCatteryContext _context;

        public TempersController(DBCatteryContext context)
        {
            _context = context;
        }

        // GET: Tempers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Temper.ToListAsync());
        }

        // GET: Tempers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temper = await _context.Temper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temper == null)
            {
                return NotFound();
            }

            return View(temper);
        }

        // GET: Tempers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tempers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Info")] Temper temper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temper);
        }

        // GET: Tempers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temper = await _context.Temper.FindAsync(id);
            if (temper == null)
            {
                return NotFound();
            }
            return View(temper);
        }

        // POST: Tempers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Info")] Temper temper)
        {
            if (id != temper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperExists(temper.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(temper);
        }

        // GET: Tempers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temper = await _context.Temper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temper == null)
            {
                return NotFound();
            }

            return View(temper);
        }

        // POST: Tempers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temper = await _context.Temper.FindAsync(id);
            _context.Temper.Remove(temper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperExists(int id)
        {
            return _context.Temper.Any(e => e.Id == id);
        }
    }
}
