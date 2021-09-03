using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosyServicios.Entities
{
    public class Proveedor
    {
        [Required]
        public int ProveedorId { get; set; }
        [Required]
        [RegularExpression(@"(\d){10}",
            ErrorMessage = "El numero de cedula debe tener 10 numeros")]
        [StringLength(10, ErrorMessage = "Longitud máxima 10", MinimumLength = 10)]
        public string Cedula { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z ]*$",
        ErrorMessage = "Solo debe ingresar letras")]
        public string Nombre { get; set; }
        [Required]
        [RegularExpression(@"[0]{1}(\d){9}",
            ErrorMessage = "El numero de telefono debe iniciar con 0 y tener 10 numeros")]
        [StringLength(10, ErrorMessage = "Longitud máxima 10", MinimumLength = 10)]


        public string Telefono { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Longitud entre 5 y 50 caracteres.",
                     MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z ]*$",
        ErrorMessage = "Solo debe ingresar letras")]
        public string Direccion { get; set; }

    }
}
