using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaEnLinea2.Data.ViewModels
{
    public class ImagesReposViewModel
    {
        public int ProdId { get; set; }
        public IFormFile Img1 { get; set; }
        public IFormFile Img2 { get; set; }
        public IFormFile Img3 { get; set; }
        public IFormFile Img4 { get; set; }
        public IFormFile Img5 { get; set; }
        public IFormFile Img6 { get; set; }
        public IFormFile Img7 { get; set; }
        public IFormFile Img8 { get; set; }
    }
}
