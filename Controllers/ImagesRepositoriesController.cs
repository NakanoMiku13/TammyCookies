using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaEnLinea2.Data;
using TiendaEnLinea2.Data.Models;
using TiendaEnLinea2.Data.Repository;
using TiendaEnLinea2.Data.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace TiendaEnLinea2.Controllers
{
    [Authorize(Roles="admin")]
    public class ImagesRepositoriesController : Controller
    {
        private protected readonly ApplicationDbContext context;
        private protected readonly IWebHostEnvironment webHostEnviroment;
        private protected ImagesUploader uploader = new ImagesUploader();
        public ImagesRepositoriesController(ApplicationDbContext context,IWebHostEnvironment webHostEnviroment)
        {
            this.context = context;
            this.webHostEnviroment = webHostEnviroment;
        }
        public IActionResult Index()
        {
            return View(context.Images.ToList());
        }
        public IActionResult Create(Producto prod)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Prod = prod;
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha cargado correctamene el producto" });
            }
            
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ImagesReposViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var prod = new ImagesRepository()
                {
                    ProdId = vm.ProdId,
                    Img1 = uploader.UploadRepo(webHostEnviroment, vm.Img1),
                    Img2 = uploader.UploadRepo(webHostEnviroment, vm.Img2),
                    Img3 = uploader.UploadRepo(webHostEnviroment, vm.Img3),
                    Img4 = uploader.UploadRepo(webHostEnviroment, vm.Img4),
                    Img5 = uploader.UploadRepo(webHostEnviroment, vm.Img5),
                    Img6 = uploader.UploadRepo(webHostEnviroment, vm.Img6),
                    Img7 = uploader.UploadRepo(webHostEnviroment, vm.Img7),
                    Img8 = uploader.UploadRepo(webHostEnviroment, vm.Img8)
                };
                await context.AddAsync(prod);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Productos");
            }else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se han podido agregar las imagenes" });
            }
        }
        public IActionResult Edit(int? id)
        {
            if (Exist(id))
            {
                var x = context.Images.FirstOrDefault(p => p.ProdId == id);
                if (x != null)
                {
                    return View(new ImagesReposViewModel() { ProdId = x.ProdId });
                }
                else
                {
                    return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se han podido encontrar el producto relacionado" });
                }
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se han podido encontrar las imagenes" });
            }
            
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(ImagesReposViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var Prod = context.Images.FirstOrDefault(p => p.ProdId == vm.ProdId);
                if (vm.Img1 != null)
                {
                    Prod.Img1 = uploader.UploadRepo(webHostEnviroment, vm.Img1);
                }
                if (vm.Img2 != null)
                {
                    Prod.Img2 = uploader.UploadRepo(webHostEnviroment, vm.Img2);
                }
                if (vm.Img3 != null)
                {
                    Prod.Img3 = uploader.UploadRepo(webHostEnviroment, vm.Img3);
                }
                if (vm.Img4 != null)
                {
                    Prod.Img4 = uploader.UploadRepo(webHostEnviroment, vm.Img4);
                }
                if (vm.Img5 != null)
                {
                    Prod.Img5 = uploader.UploadRepo(webHostEnviroment, vm.Img5);
                }
                if (vm.Img6 != null)
                {
                    Prod.Img6 = uploader.UploadRepo(webHostEnviroment, vm.Img6);
                }
                if (vm.Img7 != null)
                {
                    Prod.Img7 = uploader.UploadRepo(webHostEnviroment, vm.Img7);
                }
                if (vm.Img8 != null)
                {
                    Prod.Img8 = uploader.UploadRepo(webHostEnviroment, vm.Img8);
                }
                context.Update(Prod);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Productos");
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se han podido editar las imagenes" });
            }
        }
        private bool Exist(int? id)
        {
            if ((context.Images.FirstOrDefault(p => p.ProdId == id))==null)
            {
                return false;
            }
            return true;
        }
    }
}
