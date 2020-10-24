using System;
using System.Collections.Generic;

namespace PedidosD.Shared.Models
{
    public class Productos
    {
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public int Inventario { get; set; }
        
        public List<OrdenesDetalle> Detalle { get; set; }
    }
}