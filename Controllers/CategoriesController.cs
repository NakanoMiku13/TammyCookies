using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaEnLinea2.Data;
using TiendaEnLinea2.Data.Models;
using TiendaEnLinea2.Data.ViewModels;

namespace TiendaEnLinea2.Controllers
{
    public class CategoriesController : Controller
    {
        private protected readonly ApplicationDbContext context;
        public CategoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize(Roles="admin")]
        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }
        [Authorize(Roles = "admin")]
        public IActionResult Complete()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Category cat)
        {
            if(ModelState.IsValid)
            {
                await context.AddAsync(cat);
                await context.SaveChangesAsync();
                return View("Complete");
            }else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido crear la categoria" });
            }
        }
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            if (Exist(id))
            {
                return View(context.Categories.Find(id));
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha encontrado la categoria" });
            }
           
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(Category cat)
        {
            if(ModelState.IsValid)
            {
                context.Update(cat);
                await context.SaveChangesAsync();
                return View("Complete");
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido modificar la categoria" });
            }
        }
        [Authorize(Roles = "admin")]
        public IActionResult Delete (int? id)
        {
            if (Exist(id))
            {
                return View(context.Categories.Find(id));
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha encontrado la categoria" });
            }
            
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Category cat)
        {
            if(ModelState.IsValid)
            {
                context.Remove(cat);
                await context.SaveChangesAsync();
                return View("Complete");
            }
            else 
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido eliminar la categoria" });
            }
        }
        private bool Exist(int? id)
        {
            if ((context.Categories.Find(id)) == null)
            {
                return false;
            }
            return true;
        }
    }
}
