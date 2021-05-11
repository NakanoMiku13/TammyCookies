using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaEnLinea2.Data.ViewModels
{
    public class BrandViewModel
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public IFormFile Img { get; set; }
    }
}
