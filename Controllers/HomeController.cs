using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TiendaEnLinea2.Data;
using TiendaEnLinea2.Data.Models;
using TiendaEnLinea2.Data.Repository;
using TiendaEnLinea2.Models;
using Microsoft.Extensions.Configuration;

namespace TiendaEnLinea2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly private ApplicationDbContext context;
        protected private readonly UserManager<IdentityUser> userManager;
        protected private readonly CAU cau;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context, UserManager<IdentityUser> userManager, CAU cau)
        {
            this.context = context;
            _logger = logger;
            this.userManager = userManager;
            this.cau = cau;
            this.cau.Set();
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Contacto()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Contacto(Contacto cont)
        {
            if(ModelState.IsValid)
            {
                cont.Published = DateTime.Now;
                cont.id = new GenId().SetId();
                cont.userid = userManager.GetUserId(HttpContext.User);
                await context.AddAsync(cont);
                await context.SaveChangesAsync();
                new MailSender().SendMailToAdmin(cont);
                return View("Index");
            }
            else
            {
                return RedirectToAction("Error", "Error", new Data.ViewModels.ErrorViewModel() { Data = "Error al enviar el mensaje" });
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
