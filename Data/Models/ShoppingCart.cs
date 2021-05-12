using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaEnLinea2.Data.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext context;
        public ShoppingCart(ApplicationDbContext context)
        {
            this.context = context;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public static ShoppingCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<ApplicationDbContext>();
            string CartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", CartId);
            return new ShoppingCart(context) { ShoppingCartId = CartId };
        }
        public void AddToCart(Producto prod)
        {
            var shoppingcartItem = context.ShoppingCartItems.SingleOrDefault(p => p.Producto.id == prod.id && p.ShoppingCartId == ShoppingCartId);
            if (shoppingcartItem == null)
            {
                shoppingcartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Producto = prod,
                    Cantidad = 1
                };
                context.Add(shoppingcartItem);
            }
            else
            {
                shoppingcartItem.Cantidad++;
            }
            context.SaveChanges();
        }
        public void RemoveOne(Producto prod)
        {
            var shop = context.ShoppingCartItems.FirstOrDefault(p => p.Producto.id == prod.id && p.ShoppingCartId == ShoppingCartId);
            if (shop != null)
            {
                if (shop.Cantidad > 1)
                {
                    shop.Cantidad--;
                }
            }
            context.Update(shop);
            context.SaveChanges();
        }
        public void RemoveFromCart(Producto prod)
        {
            var shoppingcartItem = context.ShoppingCartItems.SingleOrDefault(p => p.Producto.id == prod.id && p.ShoppingCartId == ShoppingCartId);
            context.Remove(shoppingcartItem);
            context.SaveChanges();
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = context.ShoppingCartItems.Where(p => p.ShoppingCartId == ShoppingCartId).Include(p => p.Producto).ToList());
        }
        public void ClearCart()
        {
            var cartItems = context.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);
            context.RemoveRange(cartItems);
            context.SaveChanges();
        }
        public double GetShoppingCartTotal()
        {
            double x = Convert.ToDouble(context.ShoppingCartItems.Where(p => p.ShoppingCartId == ShoppingCartId).Select(p => (double?)p.Producto.Precio * p.Cantidad).Sum());
            return x;
        }
    }
}
