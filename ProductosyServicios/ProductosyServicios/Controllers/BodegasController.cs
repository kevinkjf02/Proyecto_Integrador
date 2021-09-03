using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductosyServicios.Data;
using ProductosyServicios.Entities;

namespace ProductosyServicios.Controllers
{
    public class BodegasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BodegasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bodegas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bodegas.ToListAsync());
        }

        // GET: Bodegas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodegas
                .FirstOrDefaultAsync(m => m.BodegaId == id);
            if (bodega == null)
            {
                return NotFound();
            }

            return View(bodega);
        }

        // GET: Bodegas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bodegas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("BodegaId,Codigo,Nombre,Direccion")] Bodega bodega)
        {
            if (_context.Bodegas.Any(a => a.Codigo == bodega.Codigo))
            {
                ModelState.AddModelError("Codigo", "Codigo ya existe");
            }
            if (ModelState.IsValid)
            {
                _context.Bodegas.Add(bodega);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bodega);
        }

        // GET: Bodegas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodegas.FindAsync(id);
            if (bodega == null)
            {
                return NotFound();
            }
            return View(bodega);
        }

        // POST: Bodegas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BodegaId,Codigo,Nombre,Direccion")] Bodega bodega)
        {
            if (id != bodega.BodegaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodegaExists(bodega.BodegaId))
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
            return View(bodega);
        }

        // GET: Bodegas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodegas
                .FirstOrDefaultAsync(m => m.BodegaId == id);
            if (bodega == null)
            {
                return NotFound();
            }

            return View(bodega);
        }

        // POST: Bodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodega = await _context.Bodegas.FindAsync(id);
            _context.Bodegas.Remove(bodega);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodegaExists(int id)
        {
            return _context.Bodegas.Any(e => e.BodegaId == id);
        }
    }
}
