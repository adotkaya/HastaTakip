using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaTakip.Context;
using HastaTakip.Models;

namespace HastaTakip.Views
{
    public class ZiyaretlerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZiyaretlerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ziyaretler
        public async Task<IActionResult> Index()
        {
              return _context.ziyaretler != null ? 
                          View(await _context.ziyaretler.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ziyaretler'  is null.");
        }

        // GET: Ziyaretler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ziyaretler == null)
            {
                return NotFound();
            }

            var ziyaret = await _context.ziyaretler
                .FirstOrDefaultAsync(m => m.ziyaret_id == id);
            if (ziyaret == null)
            {
                return NotFound();
            }

            return View(ziyaret);
        }

        // GET: Ziyaretler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ziyaretler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ziyaret_id,hasta_id,ziyaret_tarihi,doktor_adi,sikayet,tedavi_sekli")] Ziyaret ziyaret)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ziyaret);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ziyaret);
        }

        // GET: Ziyaretler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ziyaretler == null)
            {
                return NotFound();
            }

            var ziyaret = await _context.ziyaretler.FindAsync(id);
            if (ziyaret == null)
            {
                return NotFound();
            }
            return View(ziyaret);
        }

        // POST: Ziyaretler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ziyaret_id,hasta_id,ziyaret_tarihi,doktor_adi,sikayet,tedavi_sekli")] Ziyaret ziyaret)
        {
            if (id != ziyaret.ziyaret_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ziyaret);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZiyaretExists(ziyaret.ziyaret_id))
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
            return View(ziyaret);
        }

        // GET: Ziyaretler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ziyaretler == null)
            {
                return NotFound();
            }

            var ziyaret = await _context.ziyaretler
                .FirstOrDefaultAsync(m => m.ziyaret_id == id);
            if (ziyaret == null)
            {
                return NotFound();
            }

            return View(ziyaret);
        }

        // POST: Ziyaretler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ziyaretler == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ziyaretler'  is null.");
            }
            var ziyaret = await _context.ziyaretler.FindAsync(id);
            if (ziyaret != null)
            {
                _context.ziyaretler.Remove(ziyaret);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZiyaretExists(int id)
        {
          return (_context.ziyaretler?.Any(e => e.ziyaret_id == id)).GetValueOrDefault();
        }
    }
}
