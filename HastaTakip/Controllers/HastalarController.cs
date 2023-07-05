using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaTakip.Context;
using HastaTakip.Models;

namespace HastaTakip.Controllers
{
    public class HastalarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HastalarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hastalar
        public async Task<IActionResult> Index()
        {
            return _context.hastalar != null ?
                        View(await _context.hastalar.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.hastalar'  is null.");
        }

        // GET: Hastalar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.hastalar == null)
            {
                return NotFound();
            }

            var hasta = await _context.hastalar
                .FirstOrDefaultAsync(m => m.hasta_id == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // GET: Hastalar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hastalar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hasta_id,hasta_tc,hasta_ad_soyad,dogum_tarihi")] Hasta hasta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hasta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hasta);
        }

        // GET: Hastalar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.hastalar == null)
            {
                return NotFound();
            }

            var hasta = await _context.hastalar.FindAsync(id);
            if (hasta == null)
            {
                return NotFound();
            }
            return View(hasta);
        }

        // POST: Hastalar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("hasta_id,hasta_tc,hasta_ad_soyad,dogum_tarihi")] Hasta hasta)
        {
            if (id != hasta.hasta_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hasta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaExists(hasta.hasta_id))
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
            return View(hasta);
        }

        // GET: Hastalar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.hastalar == null)
            {
                return NotFound();
            }

            var hasta = await _context.hastalar
                .FirstOrDefaultAsync(m => m.hasta_id == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // POST: Hastalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.hastalar == null)
            {
                return Problem("Entity set 'ApplicationDbContext.hastalar'  is null.");
            }
            var hasta = await _context.hastalar.FindAsync(id);
            if (hasta != null)
            {
                _context.hastalar.Remove(hasta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaExists(int id)
        {
            return (_context.hastalar?.Any(e => e.hasta_id == id)).GetValueOrDefault();
        }
    }
}
