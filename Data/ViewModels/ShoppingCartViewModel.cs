using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaEnLinea2.Data.Models;

namespace TiendaEnLinea2.Data.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public Producto Producto { get; set; }
        public double shoppingCartTotal { get; set; }
    }
}
