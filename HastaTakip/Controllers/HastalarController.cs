using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaTakip.Context;
using HastaTakip.Models;
using Npgsql;

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
            if (_context.hastalar == null)
            {
                return Problem("Entity set 'ApplicationDbContext.hastalar' is null.");
            }

            var hastalar = await _context.hastalar.ToListAsync();
            return View(hastalar);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hasta_id,hasta_tc,hasta_ad_soyad,dogum_tarihi")] Hasta hasta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Database.ExecuteSqlInterpolatedAsync($"CALL insert_hasta({hasta.hasta_tc}, {hasta.hasta_ad_soyad}, {hasta.dogum_tarihi})");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is PostgresException postgresException && postgresException.SqlState == "23505")
                    {
                        ModelState.AddModelError(string.Empty, "Girilen TC Kimlik numarasıyla bir hasta bulunmakta. Lütfen başka bir TC giriniz.");
                        return View(hasta);
                    }
                    else if (ex.GetBaseException() is PostgresException basePostgresException && basePostgresException.SqlState == "23505")
                    {
                        ModelState.AddModelError(string.Empty, "Girilen TC Kimlik numarasıyla bir hasta bulunmakta. Lütfen başka bir TC giriniz.");
                        return View(hasta);
                    }
                    else
                    {
                        // Handle other exceptions or log the error
                        // ...

                        // Optionally, you can redirect to an error page
                        return RedirectToAction("Error", "Home");
                    }
                }


            }

            // If the ModelState is not valid or there was a duplicate key violation, return the same view with the error messages
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
                    await _context.Database.ExecuteSqlInterpolatedAsync($"CALL update_hasta({hasta.hasta_id}, {hasta.hasta_tc}, {hasta.hasta_ad_soyad}, {hasta.dogum_tarihi})");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is PostgresException postgresException && postgresException.SqlState == "23505")
                    {
                        ModelState.AddModelError(string.Empty, "Girilen TC Kimlik numarasıyla bir hasta bulunmakta. Lütfen başka bir TC giriniz.");
                        return View(hasta);
                    }
                    else if (ex.GetBaseException() is PostgresException basePostgresException && basePostgresException.SqlState == "23505")
                    {
                        ModelState.AddModelError(string.Empty, "Girilen TC Kimlik numarasıyla bir hasta bulunmakta. Lütfen başka bir TC giriniz.");
                        return View(hasta);
                    }
                    else
                    {
                        // Handle other exceptions or log the error
                        // ...

                        // Optionally, you can redirect to an error page
                        return RedirectToAction("Error", "Home");
                    }
                }
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
                return Problem("Entity set 'ApplicationDbContext.hastalar' is null.");
            }

            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"CALL delete_hasta({id})");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // Handle the exception or log the error
                throw;
            }
        }

        private bool HastaExists(int id)
        {
            return (_context.hastalar?.Any(e => e.hasta_id == id)).GetValueOrDefault();
        }
    }
}