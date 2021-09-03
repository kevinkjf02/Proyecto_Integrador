using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosyServicios.Entities
{
    public class Catalogo
    {
        [Required]
        public int CatalogoId { get; set; }

        [RegularExpression(@"^[a-zA-Z ]*$",
        ErrorMessage = "Solo debe ingresar letras")]
        [StringLength(50, ErrorMessage = "Longitud minima de 5", MinimumLength = 5)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z ]*$",
        ErrorMessage = "Solo debe ingresar letras")]
        public string Descripcion { get; set; }
        

    }
}
