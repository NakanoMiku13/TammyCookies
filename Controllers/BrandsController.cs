using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaEnLinea2.Data;
using TiendaEnLinea2.Data.Models;
using TiendaEnLinea2.Data.Repository;
using TiendaEnLinea2.Data.ViewModels;

namespace TiendaEnLinea2.Controllers
{
    public class BrandsController : Controller
    {
        private protected readonly ApplicationDbContext context;
        private protected readonly IWebHostEnvironment webHostEnvironment;
        private protected ImagesUploader uploader = new ImagesUploader();
        public BrandsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(context.Brands.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(BrandViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var br = new Brand()
                {
                    Img = uploader.UploadBrands(webHostEnvironment, vm.Img),
                    Nombre = vm.Nombre
                };
                await context.AddAsync(br);
                await context.SaveChangesAsync();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido crear la marca" });
            }
        }
        public IActionResult Edit(int? id)
        {
            if ((id != null || id != 0) && Exist(id))
            {
                var br = context.Brands.Find(id);
                return View(new BrandViewModel() { id = br.id, Nombre = br.Nombre });
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha encontrado la marca" });
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(BrandViewModel vm)
        {
           if(ModelState.IsValid)
           {
                var br = context.Brands.Find(vm.id);
                br.Nombre = vm.Nombre;
                if (vm.Img != null)
                {
                    br.Img = uploader.UploadBrands(webHostEnvironment, vm.Img);
                }
                context.Update(br);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Admin");
           }
           else
           {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido editar la marca" });
           }
        }
        public IActionResult Delete(int? id)
        {
            if ((id != null || id != 0) && Exist(id))
            {
                var br = context.Brands.Find(id);
                return View(new BrandViewModel() { id = br.id, Nombre = br.Nombre });
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha encontrado la marca" });
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(BrandViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var br = context.Brands.Find(vm.id);
                context.Remove(br);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido eliminar la marca" });
            }
        }
        private bool Exist(int? id)
        {
            var data = context.Brands.Find(id);
            if (data == null)
            {
                return false;
            }
            return true;
        }
    }
}
