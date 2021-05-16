using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaEnLinea2.Data;
using TiendaEnLinea2.Data.Models;
using TiendaEnLinea2.Data.ViewModels;

namespace Namespace
{
    public class DeliveriesController : Controller
    {
        private protected readonly ApplicationDbContext context;
        public DeliveriesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Delivery.ToList());
        }
        public IActionResult Create(){ 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Delivery delivery){
            if(ModelState.IsValid){
                await context.AddAsync(delivery);
                await context.SaveChangesAsync();
                return RedirectToAction("Index","Deliveries");
            }else{
                return RedirectToAction("Error","Error",new ErrorViewModel(){Data="No se ha podido agregar la fecha de entrega"});
            }
        }
        public IActionResult Edit(int? id){
            var x = context.Delivery.Find(id);
            if(x!=null){
                return View(x);
            }else{
                return RedirectToAction("Error","Error",new ErrorViewModel(){Data="No se ha encontrado el elemento"});
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Delivery delivery){
            if(ModelState.IsValid){
                context.Update(delivery);
                await context.SaveChangesAsync();
                return RedirectToAction("Index","Deliveries");
            }else{
                return RedirectToAction("Error","Error",new ErrorViewModel(){Data="No se ha podido editar la fecha"});
            }
        }
    }
}