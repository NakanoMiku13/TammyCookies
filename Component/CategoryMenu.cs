using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaEnLinea2.Data;

namespace TiendaEnLinea2.Component
{
    public class CategoryMenu:ViewComponent 
    {
        private readonly protected ApplicationDbContext context;
        public CategoryMenu(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(context.Categories.ToList());
        }
    }
}
