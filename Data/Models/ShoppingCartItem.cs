using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaEnLinea2.Data.Models
{
    public class ShoppingCartItem
    {
        public int id { get; set; }
        public int Cantidad { get; set; }
        public Producto Producto { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
