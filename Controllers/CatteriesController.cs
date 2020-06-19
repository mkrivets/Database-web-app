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
    public class CatteriesController : Controller
    {
        private readonly DBCatteryContext _context;

        public CatteriesController(DBCatteryContext context)
        {
            _context = context;
        }

        // GET: Catteries
        public async Task<IActionResult> Index(int? id, string? name)
        {
            if (id == null) return RedirectToAction("Cities","Index");
            // find catteries with appropriate city
            ViewBag.CityId = id;
            ViewBag.CityName = name;
            var dBCatteryContext = _context.Cattery.Include(c => c.City);
            return View(await dBCatteryContext.ToListAsync());
        }

        // GET: Catteries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cattery = await _context.Cattery
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cattery == null)
            {
                return NotFound();
            }

            return View(cattery);
        }

        // GET: Catteries/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
            return View();
        }

        // POST: Catteries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Adress,CityId,Capacity")] Cattery cattery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cattery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", cattery.CityId);
            return View(cattery);
        }

        // GET: Catteries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cattery = await _context.Cattery.FindAsync(id);
            if (cattery == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", cattery.CityId);
            return View(cattery);
        }

        // POST: Catteries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Adress,CityId,Capacity")] Cattery cattery)
        {
            if (id != cattery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cattery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatteryExists(cattery.Id))
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
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", cattery.CityId);
            return View(cattery);
        }

        // GET: Catteries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cattery = await _context.Cattery
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cattery == null)
            {
                return NotFound();
            }

            return View(cattery);
        }

        // POST: Catteries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cattery = await _context.Cattery.FindAsync(id);
            _context.Cattery.Remove(cattery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatteryExists(int id)
        {
            return _context.Cattery.Any(e => e.Id == id);
        }
    }
}
