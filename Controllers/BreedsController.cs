﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cats;

namespace Cats.Controllers
{
    public class BreedsController : Controller
    {
        private readonly DBCatteryContext _context;

        public BreedsController(DBCatteryContext context)
        {
            _context = context;
        }


        // GET: Breeds
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                var breeds = _context.Breed;
                return View(await breeds.ToListAsync());
            }
            ViewBag.id = id;
            var breed = _context.Breed.Where(b => b.Id == id);
            //var musicDataBaseContext = _context.Bands.Include(b => b.Country);
            return View(await breed.ToListAsync());
        }

        // GET: Breeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed = await _context.Breed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (breed == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Cats", new { id = breed.Id, name = breed.Name });
        }

        // GET: Breeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Breeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Info")] Breed breed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breed);
        }

        // GET: Breeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed = await _context.Breed.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }
            return View(breed);
        }

        // POST: Breeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Info")] Breed breed)
        {
            if (id != breed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreedExists(breed.Id))
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
            return View(breed);
        }

        // GET: Breeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed = await _context.Breed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (breed == null)
            {
                return NotFound();
            }

            return View(breed);
        }

        // POST: Breeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breed = await _context.Breed.FindAsync(id);
            _context.Breed.Remove(breed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreedExists(int id)
        {
            return _context.Breed.Any(e => e.Id == id);
        }
    }
}
