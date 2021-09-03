using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;  
using System.Threading.Tasks;

namespace ProductosyServicios.Entities
{
    public class Bodega
    {
       
        public int BodegaId { get; set; }
        [RegularExpression(@"(\d){3}[A-Z]{3}",
        ErrorMessage = "El codigo debe iniciar con 3 numeros y 3 letras mayusculas")]
        [StringLength(6, ErrorMessage = "Longitud máxima 6", MinimumLength = 6)]

        public string Codigo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]   
        [StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.",
                     MinimumLength = 6)]
        [RegularExpression(@"^[a-zA-Z ]*$",
        ErrorMessage = "Solo debe ingresar letras")]
        public string Nombre{ get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud entre 5 y 50 caracteres.",
                     MinimumLength = 5)]
        public string Direccion{ get; set; }



    }
}
