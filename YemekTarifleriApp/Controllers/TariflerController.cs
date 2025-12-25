using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YemekTarifleriApp.Data;
using YemekTarifleriApp.Models;

namespace YemekTarifleriApp.Controllers
{
    public class TariflerController : Controller
    {
        private readonly AppDbContext _context;

        public TariflerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tarifler
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Tarifler.Include(t => t.Kategori);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Tarifler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarifler
                .Include(t => t.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarif == null)
            {
                return NotFound();
            }

            return View(tarif);
        }

        // GET: Tarifler/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "Id");
            return View();
        }

        // POST: Tarifler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Malzemeler,Yapilis,ResimUrl,KategoriId")] Tarif tarif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "Id", tarif.KategoriId);
            return View(tarif);
        }

        // GET: Tarifler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarifler.FindAsync(id);
            if (tarif == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "Id", tarif.KategoriId);
            return View(tarif);
        }

        // POST: Tarifler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Malzemeler,Yapilis,ResimUrl,KategoriId")] Tarif tarif)
        {
            if (id != tarif.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarifExists(tarif.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "Id", tarif.KategoriId);
            return View(tarif);
        }

        // GET: Tarifler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarifler
                .Include(t => t.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarif == null)
            {
                return NotFound();
            }

            return View(tarif);
        }

        // POST: Tarifler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarif = await _context.Tarifler.FindAsync(id);
            if (tarif != null)
            {
                _context.Tarifler.Remove(tarif);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarifExists(int id)
        {
            return _context.Tarifler.Any(e => e.Id == id);
        }
    }
}
