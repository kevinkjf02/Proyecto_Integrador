using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductosyServicios.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductosyServicios.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }


    }
}
