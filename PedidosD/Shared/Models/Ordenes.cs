using System;
using System.Collections.Generic;

namespace PedidosD.Shared.Models
{
    public class Ordenes
    {
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public int SuplidorId { get; set; }
        public decimal Monto { get; set; }
        public List<OrdenesDetalle> Detalle { get; set; }
    }

    public class OrdenesDetalle
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
    }
}