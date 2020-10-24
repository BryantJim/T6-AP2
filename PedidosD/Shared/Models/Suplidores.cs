using System;
using System.Collections.Generic;


namespace PedidosD.Shared.Models
{
    public class Suplidores
    {
        public int SuplidorId { get; set; }
        public string Nombres { get; set; }
        public List<Ordenes> Ordenes { get; set; }
    }
}