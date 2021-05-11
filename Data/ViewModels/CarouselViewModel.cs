using Microsoft.AspNetCore.Http;

namespace TiendaEnLinea2.Data.ViewModels
{
    public class CarouselViewModel
    {
        public string id{get;set;}
        public int TabIndex{get;set;}
        public IFormFile Img{get;set;}
        public string Link{get;set;}
    }
}