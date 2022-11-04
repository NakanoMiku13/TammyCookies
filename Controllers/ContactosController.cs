using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles="admin")]
    public class ContactosController : Controller
    {
        private protected readonly ApplicationDbContext context;
        public ContactosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Contactos.ToList());
        }
        public IActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var data = context.Contactos.FirstOrDefault(p => p.id == id);
                if (data != null)
                {
                    return View(data);
                }
                else
                {
                    return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido encontrar el mensaje" });
                }
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido encontrar el mensaje" });
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Contacto conta)
        {
            if (ModelState.IsValid)
            {
                context.Remove(conta);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido eliminar el mensaje" });
            }
            
        }
        public IActionResult Answer(string userid)
        {
            if (!string.IsNullOrEmpty(userid))
            {
                var user = context.Users.Find(userid);
                if (user != null)
                {
                    var resp = new Respuesta()
                    {
                        userid = userid
                    };
                    return View(resp);
                }
                else
                {
                    return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido encontrar al usuario" });
                }
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "El usuario ingresado es invalido" });
            }
            
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Answer(Respuesta respuesta)
        {
            if (ModelState.IsValid)
            {
                respuesta.id = new GenId().SetId();
                respuesta.Fecha = DateTime.Now;
                new MailSender().SendMailToUser(respuesta, context);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido enviar el mensaje" });
            }
        }
    }
}
