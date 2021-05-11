using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaEnLinea2.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int OrderId { get; set; }
        public string userid { get; set; }
        public string RefPago { get; set; }
        public string Prodid { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
