using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TiendaEnLinea2.Data;
using TiendaEnLinea2.Data.Repository;
using TiendaEnLinea2.Data.ViewModels;

namespace TiendaEnLinea2.Controllers
{
    public class TiendaController : Controller
    {
        private readonly protected ApplicationDbContext context;
        private readonly protected UserManager<IdentityUser> userManager;
        private protected MailSender sender = new MailSender();
        public TiendaController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult Index(string Category,string Brand)
        {
            ViewBag.Carousel = context.Carousels.ToList();
            ViewBag.Brands = context.Brands.ToList();
            ViewBag.Cat = Category;
            try
            {
                if (!string.IsNullOrEmpty(Category) && string.IsNullOrEmpty(Brand))
                {
                    ViewBag.Set = true;
                    var cat = context.Categories.FirstOrDefault(p => p.Name.ToUpper() == Category.ToUpper());
                    if (cat != null)
                    {
                        var data = context.Producto.Where(p => p.CategoryId == cat.id).ToList();
                        return View(data);
                    }
                    else
                    {
                        var data = context.Producto.Where(p => p.CategoryId == Convert.ToInt32(Category)).ToList();
                        return View(data);
                    }
                }
                else if (string.IsNullOrEmpty(Category) && !string.IsNullOrEmpty(Brand))
                {
                    var brand = context.Brands.FirstOrDefault(p => p.Nombre.ToUpper() == Brand.ToUpper());
                    if (brand != null)
                    {
                        var data = context.Producto.Where(p => p.BrandId == brand.id).ToList();
                        return View(data);
                    }
                    else
                    {
                        var data = context.Producto.Where(p => p.BrandId == Convert.ToInt32(Brand)).ToList();
                        return View(data);
                    }
                }
                else if (!string.IsNullOrEmpty(Brand) && !string.IsNullOrEmpty(Category))
                {
                    ViewBag.Set = true;
                    var brand = context.Brands.FirstOrDefault(p => p.Nombre.ToUpper() == Brand.ToUpper());
                    var cat = context.Categories.FirstOrDefault(p => p.Name.ToUpper() == Category.ToUpper());
                    if (brand != null && cat != null)
                    {
                        var data = context.Producto.Where(p => p.BrandId == brand.id && p.CategoryId == cat.id).ToList();
                        return View(data);
                    }
                    else
                    {
                        var cat2 = context.Categories.FirstOrDefault(p => p.Name.ToUpper() == Category.ToUpper());
                        if (cat2 != null)
                        {
                            var data = context.Producto.Where(p => p.BrandId == Convert.ToInt32(Brand) && p.CategoryId == cat2.id).ToList();
                            return View(data);
                        }
                        else
                        {
                            cat2 = context.Categories.FirstOrDefault(p => p.id == Convert.ToInt32(Category));
                            var data = context.Producto.Where(p => p.BrandId == Convert.ToInt32(Brand) && p.CategoryId == cat2.id).ToList();
                            return View(data);
                        }
                    }
                }
                else
                {
                    return View(context.Producto.ToList());
                }
            }
            catch(Exception)
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "Error inesperado" });
            }
            
        }
        [Authorize]
        public IActionResult MisCompras()
        {
            try
            {
                var user = userManager.GetUserId(HttpContext.User);
                var data = context.Orders.Where(p => p.userid == user).OrderBy(p => p.Ordenado).ToList();
                return View(data);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "Error desconocido" });
            }
        }
        [Authorize]
        public IActionResult Details(int? id)
        {
            if(Exist(id))
            {
                var order = context.Orders.Find(id);
                var data = context.OrderDetails.Where(p => p.RefPago == order.RefPago).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha encontrado la orden" });
            }
        }
        [Authorize]
        public IActionResult Cancel(int? id)
        {
            if (Exist(id))
            {
                var order = context.Orders.Find(id);
                return View(order);
            }
            else
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = "No se ha encontrado la orden" });
            }
        }
        [Authorize]
        public ViewResult C2(int id)
        {
            try
            {
                var order = context.Orders.Find(id);
                order.Cancelado = true;
                context.Update(order);
                context.SaveChanges();
                sender.SendMailUserCancel(order);
                sender.SendMailToAdminCancelOrder(order);
                return View(nameof(Red));
            }
            catch (Exception)
            {
                return View("Extra",new ErrorViewModel() { Data = "Error desconocido" });
            }
        }
        public RedirectToActionResult Red()
        {
            return RedirectToAction("Index", "Tienda");
        }
        public RedirectToActionResult Extra(ErrorViewModel ex)
        {
            return RedirectToAction("Error", "Error", new ErrorViewModel() { Data = ex.Data });
        }
        private bool Exist(int? id)
        {
            if ((context.Orders.Find(id)) == null)
            {
                return false;
            }
            return true;
        }
    }
}
