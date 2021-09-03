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
    public class InventariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inventarios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Inventarios.Include(i => i.Catalogo).Include(i => i.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Inventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventarios
                .Include(i => i.Catalogo)
                .Include(i => i.Producto)
                .FirstOrDefaultAsync(m => m.InventarioId == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: Inventarios/Create
        public IActionResult Create()
        {
            ViewData["CatalogoId"] = new SelectList(_context.Catalogos, "CatalogoId", "Nombre");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "CodigoProducto");
            return View();
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventarioId,ProductoId,CatalogoId,FechaIngreso,Cantidad")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatalogoId"] = new SelectList(_context.Catalogos, "CatalogoId", "Nombre", inventario.CatalogoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "CodigoProducto", inventario.ProductoId);
            return View(inventario);
        }

        // GET: Inventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            ViewData["CatalogoId"] = new SelectList(_context.Catalogos, "CatalogoId", "Nombre", inventario.CatalogoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "CodigoProducto", inventario.ProductoId);
            return View(inventario);
        }

        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventarioId,ProductoId,CatalogoId,FechaIngreso,Cantidad")] Inventario inventario)
        {
            if (id != inventario.InventarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioExists(inventario.InventarioId))
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
            ViewData["CatalogoId"] = new SelectList(_context.Catalogos, "CatalogoId", "Nombre", inventario.CatalogoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "CodigoProducto", inventario.ProductoId);
            return View(inventario);
        }

        // GET: Inventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventarios
                .Include(i => i.Catalogo)
                .Include(i => i.Producto)
                .FirstOrDefaultAsync(m => m.InventarioId == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);
            _context.Inventarios.Remove(inventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioExists(int id)
        {
            return _context.Inventarios.Any(e => e.InventarioId == id);
        }
    }
}
