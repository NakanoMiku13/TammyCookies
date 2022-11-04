using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaEnLinea2.Data.ViewModels;

namespace TiendaEnLinea2.Controllers
{
    public class ErrorController : Controller
    { 
        public IActionResult Error(ErrorViewModel vm)
        {
            ViewBag.Data = vm.Data;
            return View();
        }
    }
}
