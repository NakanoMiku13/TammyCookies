using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly protected ApplicationDbContext context;
        private readonly protected UserManager<IdentityUser> userManager;
        private readonly protected ShoppingCart shoppingCart;
        private readonly protected ReferenciaPago refi = new ReferenciaPago();
        public ShoppingCartController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ShoppingCart shoppingCart)
        {
            this.context = context;
            this.userManager = userManager;
            this.shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var data = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = data;
            var vm = new ShoppingCartViewModel()
            {
                ShoppingCart = shoppingCart,
                shoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };
            return View(vm);
        }
        public RedirectToActionResult AddToCart(string id)
        {
            var selected = context.Producto.FirstOrDefault(p => p.id == Convert.ToInt32(id));
            if (selected != null)
            {
                shoppingCart.AddToCart(selected);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult AddOne (string id)
        {
            var selected = context.Producto.FirstOrDefault(p => p.id == Convert.ToInt32(id));
            if (selected != null)
            {
                shoppingCart.AddToCart(selected);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveOne(string id)
        {
            var selected = context.Producto.FirstOrDefault(p => p.id == Convert.ToInt32(id));
            if (selected != null)
            {
                shoppingCart.RemoveOne(selected);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromCart(string id)
        {
            var selected = context.Producto.FirstOrDefault(p => p.id == Convert.ToInt32(id));
            if (selected != null)
            {
                shoppingCart.RemoveFromCart(selected);
            }
            return RedirectToAction("Index");
        }
    }
}
