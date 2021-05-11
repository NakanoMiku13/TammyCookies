using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaEnLinea2.Data.Models
{
    public class Order
    {
        public int id { get; set; }
        public string userid { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Numero { get; set; }
        public bool Politicas { get; set; }
        public bool Enviado { get; set; }
        public DateTime Ordenado { get; set; }
        public DateTime FechaDeEnvio { get; set; }
        public string RefPago { get; set; }
        public bool Visible { get; set; }
        public bool Cancelado { get; set; }
        public decimal Total { get; set; }
    }
}
