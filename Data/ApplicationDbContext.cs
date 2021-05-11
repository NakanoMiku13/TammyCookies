using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaEnLinea2.Controllers;
using TiendaEnLinea2.Data.Models;

namespace TiendaEnLinea2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Tempo> tmp { get; set; }
        public DbSet<ImagesRepository> Images { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Carousel> Carousels {get;set;}
    }
}
