using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TiendaEnLinea2.Data;
using TiendaEnLinea2.Data.Models;
using TiendaEnLinea2.Data.Repository;
using TiendaEnLinea2.Data.ViewModels;

namespace TiendaEnLinea2.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private protected readonly ApplicationDbContext context;
        private protected readonly UserManager<IdentityUser> userManager;
        private protected readonly ShoppingCart shoppingCart;
        protected MailSender sender = new MailSender();
        protected ReferenciaPago refe = new ReferenciaPago();
        
        public OrdersController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ShoppingCart shopping)
        {
            this.context = context;
            this.userManager = userManager;
            shoppingCart = shopping;
        }
        protected string GetUser()
        {
            return userManager.GetUserId(HttpContext.User);
        }
        public IActionResult CheckOut(string dataid)
        {
            ViewBag.id = dataid;
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CheckOut(Order order,string sid)
        {
            if(ModelState.IsValid)
            {
                decimal total = 0;
                var orders = shoppingCart.GetShoppingCartItems();
                shoppingCart.ShoppingCartItems = orders;
                var userid = GetUser();
                if (!string.IsNullOrEmpty(sid))
                {
                    total = Convert.ToDecimal(sid);
                }
                else
                {
                    total = Convert.ToDecimal(shoppingCart.GetShoppingCartTotal());
                }
                order.RefPago = refe.GenRef(userid, context);
                foreach (var item in shoppingCart.ShoppingCartItems)
                {
                    var orderdetails = new OrderDetail()
                    {
                        OrderId = order.id,
                        userid = userid,
                        RefPago = order.RefPago
                    };
                    orderdetails.Prodid = item.Producto.id.ToString();
                    orderdetails.Cantidad = item.Cantidad;
                    orderdetails.Total = item.Producto.Precio * item.Cantidad;
                    await context.AddAsync(orderdetails);
                    await context.SaveChangesAsync();
                }
                order.Visible = true;
                var user = await context.Users.FindAsync(userid);
                order.Mail = user.Email;
                user.PhoneNumber = order.Numero;
                order.Ordenado = DateTime.Now;
                order.Total = total;
                order.userid = userid;
                order.Pay=false;
                await context.AddAsync(new Tempo()
                {
                    order=order,
                    ordered=order.Ordenado,
                    orderid=order.id.ToString(),
                    RefPago=order.RefPago,
                    userid=userid
                });
                context.Update(user);
                await context.AddAsync(order);
                await context.SaveChangesAsync();
                return RedirectToAction("Complete", order);
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha podido completar la compra" });
            }
            
        }
        public IActionResult Complete(Order order)
        {
            double data = Convert.ToDouble(order.Total);
            ViewBag.Total = data.ToString(CultureInfo.CreateSpecificCulture("en-US"));
            ViewBag.id = order.id.ToString();
            return View(order);
        }
        public IActionResult OnAprove() 
        {
            try
            {
                var order = context.tmp.FirstOrDefault(p => p.userid == GetUser() && (p.ordered.Day == DateTime.Now.Day && p.ordered.Month == DateTime.Now.Month && p.ordered.Year == DateTime.Now.Year));
                order.order = context.Orders.FirstOrDefault(p => p.RefPago == order.RefPago);
                sender.SendMailToUserTicket(context.OrderDetails.Where(p => p.RefPago == order.RefPago).ToList(), order.order, context);
                sender.SendMailToAdminNewSell(order.order, context.OrderDetails.Where(p => p.RefPago == order.RefPago).ToList(), context);
                ViewBag.Refe = order.RefPago;
                var orders = shoppingCart.GetShoppingCartItems();
                shoppingCart.ShoppingCartItems = orders;
                shoppingCart.ClearCart();
                ClearTmp(order);
                return View();
            }
            catch(Exception ex)
            {
                string x = ex.ToString();
                return RedirectToAction("Error", "Error", new ErrorViewModel(){Data="No se ha podido aprobar la compra"});
            }
        }
        protected void ClearTmp(Tempo tmp)
        {
            context.Remove(tmp);
            context.SaveChanges();
        }
        private protected Order GetOrder(string id)
        {
            return context.Orders.FirstOrDefault(p=>p.id==Convert.ToInt32(id));
        }
    }
    public class Tempo
    {
        public int id { get; set; }
        public string orderid { get; set; }
        public string RefPago { get; set; }
        public string userid { get; set; }
        public DateTime ordered { get; set; }
        public Order order { get; set; }
    }
}
