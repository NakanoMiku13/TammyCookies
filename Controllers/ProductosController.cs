using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    public class ProductosController : Controller
    {
        protected private readonly ApplicationDbContext context;
        protected readonly IWebHostEnvironment webHostEnvironment;
        protected ImagesUploader imagesUploader = new ImagesUploader();
        public ProductosController(ApplicationDbContext ctx,IWebHostEnvironment webhost)
        {
            context = ctx;
            webHostEnvironment = webhost;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var Lista = context.Producto.ToList();
            return View(Lista);
        }
        public IActionResult Create()
        {
            ViewData["Category"] = new SelectList(context.Categories, "id", "Name");
            ViewData["Brand"] = new SelectList(context.Brands, "id", "Nombre");
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ProductoViewModel produc)
        {
            if(ModelState.IsValid)
            {
                var prod = new Producto()
                {
                    Descripcion = produc.Descripcion,
                    Nombre = produc.Nombre,
                    Precio = produc.Precio,
                    Imagen = imagesUploader.UploadProduct(produc, webHostEnvironment),
                    CategoryId = produc.CategoryId,
                    BrandId=0
                };
                await context.AddAsync(prod);
                await context.SaveChangesAsync();
                ViewData["Category"] = new SelectList(context.Categories, "id", "Name", produc.CategoryId);
                ViewData["Brand"] = new SelectList(context.Brands, "id", "Nombre",produc.BrandId);
                return RedirectToAction("Create","ImagesRepositories",prod);
            }
            else
            {
                var data = new ErrorViewModel()
                {
                    Data = "No se ha podido crear el producto"
                };
                return RedirectToAction("Error","Error",data);
            }
        }
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            if (Exist(id))
            {
                var prod = context.Producto.Find(id);
                var data = new ProductoViewModel()
                {
                    id = prod.id,
                    Descripcion = prod.Descripcion,
                    Nombre = prod.Nombre,
                    Precio = prod.Precio,
                    CategoryId = prod.CategoryId,
                    BrandId = prod.BrandId
                };
                ViewData["Category"] = new SelectList(context.Categories, "id", "Name");
                ViewData["Brand"] = new SelectList(context.Brands, "id", "Nombre");
                return View(data);
            }
            else
            {
                var data = new ErrorViewModel()
                {
                    Data = "No se ha podido encontrar el producto"
                };
                return RedirectToAction("Error", "Error", data);
            }
            
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(ProductoViewModel producto)
        {
            if(ModelState.IsValid)
            {
                var prod = await context.Producto.FirstOrDefaultAsync(p=>p.id==producto.id);
                prod.Nombre = producto.Nombre;
                prod.Descripcion = producto.Descripcion;
                prod.Precio = producto.Precio;
                if (producto.Imagen != null)
                {
                    prod.Imagen = imagesUploader.UploadProduct(producto, webHostEnvironment);
                }
                prod.CategoryId = producto.CategoryId;
                prod.BrandId = producto.BrandId;
                context.Producto.Update(prod);
                await context.SaveChangesAsync();
                ViewData["Category"] = new SelectList(context.Categories, "id", "Name", producto.CategoryId);
                ViewData["Brand"] = new SelectList(context.Brands, "id", "Nombre",producto.BrandId);
                return View("Complete");
            }
            else
            {
                var data = new ErrorViewModel()
                {
                    Data = "No se ha podido modificar el producto"
                };
                return RedirectToAction("Error", "Error", data);
            }
        }
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {
            if (Exist(id))
            {
                return View(context.Producto.Find(id));
            }
            else
            {
                var data = new ErrorViewModel()
                {
                    Data = "No se ha podido encontrar el producto"
                };
                return RedirectToAction("Error", "Error", data);
            }
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Producto producto)
        {
            if(ModelState.IsValid)
            {
                context.Producto.Remove(producto);
                await context.SaveChangesAsync();
                return View("Complete");
            }
            else
            {
                var data = new ErrorViewModel()
                {
                    Data = "No se ha podido eliminar el producto"
                };
                return RedirectToAction("Error", "Error", data);
            }
        }
        public IActionResult Complete()
        {
            return View();
        }
        private bool Exist(int? id)
        {
            if ((context.Producto.Find(id)) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
