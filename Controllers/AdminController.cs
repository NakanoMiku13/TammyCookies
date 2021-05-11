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
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;
        private protected MailSender sender = new MailSender();
        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OrderMenu()
        {
            return View(context.Orders.ToList().Where(p => p.Visible == true).OrderBy(p => p.Ordenado));
        }
        public ViewResult ClearTmp()
        {
            var tmplist = context.ShoppingCartItems.ToList();
            context.ShoppingCartItems.RemoveRange(tmplist);
            var tmplist2 = context.tmp.ToList();
            context.tmp.RemoveRange(tmplist2);
            context.SaveChanges();
            return View("Index");
        }
        public IActionResult EditOrder(int? id)
        {
            if((id!=null || id != 0) && Exist(id))
            {
                return View(context.Orders.Find(id));
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "Orden no encontrada" });
            }
            
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditOrder(Order order)
        {
            if(ModelState.IsValid)
            {
                context.Update(order);
                await context.SaveChangesAsync();
                return RedirectToAction("OrderMenu","Admin");
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data="No se ha podido modificar la orden"});
            }
        }
        public IActionResult DetailsOrder(int? id)
        {
            if (Exist(id))
            {
                var order = context.Orders.Find(id);
                var list = context.OrderDetails.Where(p => p.RefPago == order.RefPago).ToList();
                List<TmpList> lista = new List<TmpList>();
                foreach (var x in list)
                {
                    lista.Add(new TmpList()
                    {
                        prod = context.Producto.FirstOrDefault(p => p.id == Convert.ToInt32(x.Prodid)),
                        Cantidad = x.Cantidad
                    });
                }
                return View(lista);
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido encontrar la orden" });
            }

        }
        public IActionResult OrdenesOcultas()
        {
            return View(context.Orders.Where(p => p.Visible == false).OrderBy(p => p.Ordenado).ToList());
        }
        public RedirectToActionResult Redirect()
        {
            return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido realizar la operacion" });
        }
        public ViewResult Send(int id)
        {
            if (Exist(id))
            {
                var order = context.Orders.Find(id);
                if (!order.Enviado)
                {
                    order.Enviado = true;
                    order.FechaDeEnvio = DateTime.Now;
                    sender.SendMailUserSended(order);
                    context.Update(order);
                    context.SaveChanges();
                }
                return View("Index");
            }
            else
            {
                return View(nameof(Redirect));
            }
        }
        public ViewResult ShowOrder(int id)
        {
            if (Exist(id))
            {
                var order = context.Orders.Find(id);
                order.Visible = true;
                context.Update(order);
                context.SaveChanges();
                return View("Index");
            }
            else
            {
                return View(nameof(Redirect));
            }
        }
        public ViewResult HideOrder(int id)
        {
            if (Exist(id))
            {
                var order = context.Orders.Find(id);
                order.Visible = false;
                context.Update(order);
                context.SaveChanges();
                return View("Index");
            }
            else
            {
                return View(nameof(Redirect));
            }
        }
        private bool Exist(int? id)
        {
            var data = context.Orders.Find(id);
            if (data == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public class TmpList
    {
        public Producto prod { get; set; }
        public int Cantidad { get; set; }
    }
}
