using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using TiendaEnLinea2.Data;
using TiendaEnLinea2.Data.Models;
using TiendaEnLinea2.Data.Repository;
using TiendaEnLinea2.Data.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace TiendaEnLinea2.Controllers
{
    [Authorize(Roles = "admin")]
    public class CarouselsController:Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment enviroment;
        public CarouselsController(ApplicationDbContext context, IWebHostEnvironment web)
        {
            this.context=context;
            enviroment=web;
        }
        public IActionResult Index(){
            return View(context.Carousels.ToList());
        }
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarouselViewModel vm){
            if(ModelState.IsValid){
                int count = context.Carousels.Count();
                count++;
                var x = new Carousel(){
                    id=Guid.NewGuid().ToString(),
                    TabIndex=count,
                    Img=new ImagesUploader().UploadCarousel(enviroment,vm.Img),
                    Link=vm.Link
                };
                await context.AddAsync(x);
                await context.SaveChangesAsync();
                return RedirectToAction("Index","Admin");
            }else{
                return RedirectToAction("Error","Error",new ErrorViewModel(){Data="No se ha podido crear el carusel"});
            }        
        }
        public IActionResult Edit(string id){
            var x = context.Carousels.Find(id);
            if(x!=null){
                var vm = new CarouselViewModel(){
                    id=id,
                    Link=x.Link
                };
                return View(vm);
            }else{
                return RedirectToAction("Error","Error",new ErrorViewModel(){Data="No se ha podido encontrar el carusel"});
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarouselViewModel vm){
            if(ModelState.IsValid){
                var data = context.Carousels.Find(vm.id);
                if(data!=null){
                    if(vm.Img!=null){
                        data.Img=new ImagesUploader().UploadCarousel(enviroment,vm.Img);
                    }
                    data.Link=vm.Link;
                    context.Update(data);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index","Carousels");
                }else{
                    return RedirectToAction("Error","Error",new ErrorViewModel(){Data="No se ha podido editar el carusel"});
                }  
            }else{
                return RedirectToAction("Error","Error",new ErrorViewModel(){Data="No se ha podido encontrar el carusel"});
            }      
        }
    }
}