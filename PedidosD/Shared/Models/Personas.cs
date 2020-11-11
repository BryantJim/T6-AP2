using PedidosD.Shared.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PedidosD.Shared.Models
{
    public class Personas
    {
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombres { get; set; }

        [ValidacionCedula]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        public double Balance { get; set; }
    }
}
