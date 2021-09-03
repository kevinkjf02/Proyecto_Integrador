using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosyServicios.Entities
{
    public class Producto
    {
        [Required]
        
    public int ProductoId { get; set; }
        [Required]
        [RegularExpression(@"(\d){3}[A-Z]{3}",
        ErrorMessage = "El odigo debe iniciar con 3 numeros y 3 letras mayusculas")]
    [StringLength(6, ErrorMessage = "Longitud máxima 6", MinimumLength = 6)]
    public string CodigoProducto { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z ]*$",
        ErrorMessage = "Solo debe ingresar letras")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]

        public float Precio { get; set; }
        [ForeignKey("Proveedor")]
        [DisplayName("Proveedor")]
        [Required]
        public int ProveedorId { get; set; }
        [ForeignKey("Bodega")]
        [DisplayName("Bodega")]
        [Required]
        public int BodegaId { get; set; }

       
        public Bodega Bodega { get; set; }
        public Proveedor Proveedor { get; set; }
    

    }
}
