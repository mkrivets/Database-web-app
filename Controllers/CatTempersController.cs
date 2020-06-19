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
    public class CatTempersController : Controller
    {
        private readonly DBCatteryContext _context;

        public CatTempersController(DBCatteryContext context)
        {
            _context = context;
        }

        // GET: CatTempers
        public async Task<IActionResult> Index()
        {
            var dBCatteryContext = _context.CatTemper.Include(c => c.Cat).Include(c => c.Temper);
            return View(await dBCatteryContext.ToListAsync());
        }

        // GET: CatTempers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTemper = await _context.CatTemper
                .Include(c => c.Cat)
                .Include(c => c.Temper)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catTemper == null)
            {
                return NotFound();
            }

            return View(catTemper);
        }

        // GET: CatTempers/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.Cat, "Id", "Name");
            ViewData["TemperId"] = new SelectList(_context.Temper, "Id", "Name");
            return View();
        }

        // POST: CatTempers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatId,TemperId")] CatTemper catTemper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catTemper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.Cat, "Id", "Name", catTemper.CatId);
            ViewData["TemperId"] = new SelectList(_context.Temper, "Id", "Name", catTemper.TemperId);
            return View(catTemper);
        }

        // GET: CatTempers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTemper = await _context.CatTemper.FindAsync(id);
            if (catTemper == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.Cat, "Id", "Name", catTemper.CatId);
            ViewData["TemperId"] = new SelectList(_context.Temper, "Id", "Name", catTemper.TemperId);
            return View(catTemper);
        }

        // POST: CatTempers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CatId,TemperId")] CatTemper catTemper)
        {
            if (id != catTemper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catTemper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTemperExists(catTemper.Id))
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
            ViewData["CatId"] = new SelectList(_context.Cat, "Id", "Name", catTemper.CatId);
            ViewData["TemperId"] = new SelectList(_context.Temper, "Id", "Name", catTemper.TemperId);
            return View(catTemper);
        }

        // GET: CatTempers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTemper = await _context.CatTemper
                .Include(c => c.Cat)
                .Include(c => c.Temper)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catTemper == null)
            {
                return NotFound();
            }

            return View(catTemper);
        }

        // POST: CatTempers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTemper = await _context.CatTemper.FindAsync(id);
            _context.CatTemper.Remove(catTemper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatTemperExists(int id)
        {
            return _context.CatTemper.Any(e => e.Id == id);
        }
    }
}
