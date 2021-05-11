using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TiendaEnLinea2.Data.Repository
{
    public class CAU
    {
        private readonly IConfiguration config;
        private readonly ApplicationDbContext context;
        public CAU(IConfiguration config,ApplicationDbContext context)
        {
            this.config = config;
            this.context = context;
        }
        public CAU()
        {
            Set();
        }
        public void Set()
        {
            Create();
        }
        private protected void Create()
        {
            IConfiguration con = config.GetSection("Secrets:Auth:Ad");
            string mail = con["ClientId"];
            if ((context.Users.FirstOrDefault(p => p.Email == mail)) == null)
            {
                var User = new IdentityUser()
                {
                    Email = mail,
                    NormalizedEmail = mail.ToUpper(),
                    UserName = mail.ToUpper(),
                    NormalizedUserName = mail.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = con["ClientSecret"]
                };
                string rol = con["Role"];
                var Role = new IdentityRole()
                {
                    Name = rol,
                    NormalizedName = rol.ToUpper()
                };
                context.Add(User);
                context.Add(Role);
                context.SaveChanges();
                context.Add(new IdentityUserRole<string>()
                {
                    RoleId = Role.Id,
                    UserId = User.Id
                });
                context.SaveChanges();
            }
        }
    }
}
