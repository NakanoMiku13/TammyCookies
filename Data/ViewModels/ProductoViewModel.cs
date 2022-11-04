using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaEnLinea2.Data.ViewModels
{
    public class ProductoViewModel
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public IFormFile Imagen { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
