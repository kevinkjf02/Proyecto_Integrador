using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosyServicios.Entities
{
    public class Inventario
    {
        [Required]
        
        public int InventarioId { get; set; }

        
        [ForeignKey("Producto")]
        [DisplayName("Producto")]
        [Required]
        public int ProductoId { get; set; }


        [ForeignKey("Catalogo")]
        [DisplayName("Metodo de salida")]
        [Required]
        public int CatalogoId { get; set; }
        [Required]
        public DateTime FechaIngreso { get; set; }
        public int Cantidad { get; set; }

        public Producto Producto { get; set; }
        public Catalogo Catalogo  { get; set; }
    }
}
