using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaEnLinea2.Controllers;
using TiendaEnLinea2.Data;
using TiendaEnLinea2.Data.Models;
using TiendaEnLinea2.Data.Repository;

namespace TiendaEnLinea2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }
        public static IConfiguration StaticConfig {get; private set;}
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddScoped<ProductosController>();
            services.AddScoped<HomeController>();
            services.AddScoped<CAU>();
            services.AddScoped<MailSender>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddHttpClient();
            services.AddHsts(options=>{
                options.IncludeSubDomains=true;
                options.Preload=true;
                options.MaxAge=TimeSpan.FromHours(100);
            });
            services.AddRazorPages();
            services.AddAuthentication().AddMicrosoftAccount(options =>
            {
                options.ClientId = Configuration["Secrets:Auth:Microsoft:ClientId"];
                options.ClientSecret = Configuration["Secrets:Auth:Microsoft:ClientSecret"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Tienda}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
