using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TiendaEnLinea2.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TiendaEnLinea2.Data.Repository
{
    public class ImagesUploader
    {
        public string UploadProduct(ProductoViewModel vm,IWebHostEnvironment webHostEnvironment)
        {
            string FileName = null;
            if (vm.Imagen != null)
            {
                string uploaDir = Path.Combine(webHostEnvironment.WebRootPath, "UploadedImages");
                FileName = Guid.NewGuid().ToString() + "-" + vm.Imagen.FileName;
                string FilePath = Path.Combine(uploaDir, FileName);
                using(var FileStream = new FileStream(FilePath, FileMode.Create))
                {
                    vm.Imagen.CopyTo(FileStream);
                }
            }
            return FileName;
        }
        public string UploadRepo(IWebHostEnvironment webHostEnvironment, IFormFile Archivo)
        {
            string FileName = null;
            if (Archivo != null)
            {
                string uploaDir = Path.Combine(webHostEnvironment.WebRootPath, "ImagesRespos");
                FileName = Guid.NewGuid().ToString() + "-" + Archivo.FileName;
                string FilePath = Path.Combine(uploaDir, FileName);
                using (var FileStream = new FileStream(FilePath, FileMode.Create))
                {
                    Archivo.CopyTo(FileStream);
                }
            }
            return FileName;
        }
        public string UploadBrands(IWebHostEnvironment webHostEnvironment, IFormFile Archivo)
        {
            string FileName = null;
            if (Archivo != null)
            {
                string uploaDir = Path.Combine(webHostEnvironment.WebRootPath, "BrandsImg");
                FileName = Guid.NewGuid().ToString() + "-" + Archivo.FileName;
                string FilePath = Path.Combine(uploaDir, FileName);
                using (var FileStream = new FileStream(FilePath, FileMode.Create))
                {
                    Archivo.CopyTo(FileStream);
                }
            }
            return FileName;
        }
        public string UploadCarousel(IWebHostEnvironment webHostEnvironment, IFormFile Archivo)
        {
            string FileName = null;
            if (Archivo != null)
            {
                string uploaDir = Path.Combine(webHostEnvironment.WebRootPath, "CarouselImg");
                FileName = Guid.NewGuid().ToString() + "-" + Archivo.FileName;
                string FilePath = Path.Combine(uploaDir, FileName);
                using (var FileStream = new FileStream(FilePath, FileMode.Create))
                {
                    Archivo.CopyTo(FileStream);
                }
            }
            return FileName;
        }
    }
}
