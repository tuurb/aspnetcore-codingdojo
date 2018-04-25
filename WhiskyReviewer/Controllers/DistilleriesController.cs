using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiskyReviewer.Models;

namespace WhiskyReviewer.Controllers
{
    public class DistilleriesController : Controller
    {
        private readonly WhiskyReviewerContext _context;

        public DistilleriesController(WhiskyReviewerContext context)
        {
            _context = context;
        }

        // GET: Distilleries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Distilleries.ToListAsync());
        }

        // GET: Distilleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distillery = await _context.Distilleries
                .SingleOrDefaultAsync(m => m.Id == id);
            if (distillery == null)
            {
                return NotFound();
            }

            return View(distillery);
        }

        // GET: Distilleries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Distilleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Country")] Distillery distillery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(distillery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(distillery);
        }

        // GET: Distilleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distillery = await _context.Distilleries.SingleOrDefaultAsync(m => m.Id == id);
            if (distillery == null)
            {
                return NotFound();
            }
            return View(distillery);
        }

        // POST: Distilleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Country")] Distillery distillery)
        {
            if (id != distillery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distillery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistilleryExists(distillery.Id))
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
            return View(distillery);
        }

        // GET: Distilleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distillery = await _context.Distilleries
                .SingleOrDefaultAsync(m => m.Id == id);
            if (distillery == null)
            {
                return NotFound();
            }

            return View(distillery);
        }

        // POST: Distilleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distillery = await _context.Distilleries.SingleOrDefaultAsync(m => m.Id == id);
            _context.Distilleries.Remove(distillery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistilleryExists(int id)
        {
            return _context.Distilleries.Any(e => e.Id == id);
        }
    }
}
