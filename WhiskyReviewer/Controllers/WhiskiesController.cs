﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiskyReviewer.Models;

namespace WhiskyReviewer.Controllers
{
    public class WhiskiesController : Controller
    {
        private readonly WhiskyReviewerContext _context;

        public WhiskiesController(WhiskyReviewerContext context)
        {
            _context = context;
        }

        // GET: Whiskies
        public async Task<IActionResult> Index()
        {
            var whiskyReviewerContext = _context.Whiskies.Include(w => w.Distillery);
            return View(await whiskyReviewerContext.ToListAsync());
        }

        // GET: Whiskies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whisky = await _context.Whiskies.Include(w => w.Distillery).SingleOrDefaultAsync(m => m.Id == id);
            if (whisky == null)
            {
                return NotFound();
            }

            return View(whisky);
        }

        // GET: Whiskies/Create
        public IActionResult Create()
        {
            ViewData["DistilleryId"] = new SelectList(_context.Distilleries, "Id", "Name");
            return View();
        }

        // POST: Whiskies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Category,StatedAge,DistilleryId")] Whisky whisky)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whisky);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistilleryId"] = new SelectList(_context.Distilleries, "Id", "Name", whisky.DistilleryId);
            return View(whisky);
        }

        // GET: Whiskies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whisky = await _context.Whiskies.SingleOrDefaultAsync(m => m.Id == id);
            if (whisky == null)
            {
                return NotFound();
            }
            ViewData["DistilleryId"] = new SelectList(_context.Distilleries, "Id", "Name", whisky.DistilleryId);
            return View(whisky);
        }

        // POST: Whiskies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Category,StatedAge,DistilleryId")] Whisky whisky)
        {
            if (id != whisky.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whisky);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhiskyExists(whisky.Id))
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
            ViewData["DistilleryId"] = new SelectList(_context.Distilleries, "Id", "Name", whisky.DistilleryId);
            return View(whisky);
        }

        // GET: Whiskies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whisky = await _context.Whiskies
                .Include(w => w.Distillery)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (whisky == null)
            {
                return NotFound();
            }

            return View(whisky);
        }

        // POST: Whiskies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whisky = await _context.Whiskies.SingleOrDefaultAsync(m => m.Id == id);
            _context.Whiskies.Remove(whisky);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhiskyExists(int id)
        {
            return _context.Whiskies.Any(e => e.Id == id);
        }
    }
}
