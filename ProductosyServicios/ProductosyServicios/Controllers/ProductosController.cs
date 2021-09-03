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
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index( string searchString)
        {
            ViewData["CurrentFiler"] = searchString;
            var categoria = from s in _context.Productos select s;
            if (String.IsNullOrEmpty(searchString))
            {
                categoria = categoria.Where(s=>s.Nombre.Contains(searchString)|| s.CodigoProducto.Contains(searchString)|| s.Bodega.Nombre.Contains(searchString) );            }
            var applicationDbContext = _context.Productos.Include(p => p.Bodega).Include(p => p.Proveedor);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Bodega)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["BodegaId"] = new SelectList(_context.Bodegas, "BodegaId", "Nombre");
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Cedula");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,CodigoProducto,Nombre,Precio,ProveedorId,BodegaId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BodegaId"] = new SelectList(_context.Bodegas, "BodegaId", "Nombre", producto.BodegaId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Cedula", producto.ProveedorId);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["BodegaId"] = new SelectList(_context.Bodegas, "BodegaId", "Nombre", producto.BodegaId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Cedula", producto.ProveedorId);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,CodigoProducto,Nombre,Precio,ProveedorId,BodegaId")] Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoId))
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
            ViewData["BodegaId"] = new SelectList(_context.Bodegas, "BodegaId", "Nombre", producto.BodegaId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Cedula", producto.ProveedorId);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Bodega)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoId == id);
        }
    }
}
