using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaEnLinea2.Data.Models
{
    public class Contacto
    {
        public string id { get; set; }
        public string userid { get; set; }
        public DateTime Published { get; set; }
        public string Mensaje { get; set; }
    }
}
