using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PedidosD.Shared.Models
{
    public class Prestamos
    {
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio")]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "Campo obligatorio"), Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Debe tener un minimo de 1")]
        public double Monto { get; set; }

        public double Balance { get; set; }
    }
}
