using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaEnLinea2.Data;

namespace TiendaEnLinea2.Component
{
    public class UserMenu:ViewComponent
    {
        private protected readonly ApplicationDbContext context;
        private readonly protected UserManager<IdentityUser> userManager;
        public UserMenu(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var user = context.Users.Find(userManager.GetUserId(HttpContext.User));
            if (user != null)
            {
                var role = context.Roles.FirstOrDefault(p => p.NormalizedName == "ADMIN");
                var userRole = context.UserRoles.FirstOrDefault(p => p.RoleId == role.Id && p.UserId == user.Id);
                if (userRole != null)
                {
                    ViewBag.Role = true;
                }
            }
            return View();
        }
    }
}
