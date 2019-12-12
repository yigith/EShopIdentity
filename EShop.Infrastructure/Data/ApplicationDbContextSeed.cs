using EShop.ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EShop.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static void Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { CategoryName = "Clothing" });
                context.Categories.Add(new Category { CategoryName = "Shoes" });
                context.SaveChanges();

            }
            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(new ApplicationUser { Email = "yigith2@gmail.com", UserName = "yigith2@gmail.com", EmailConfirmed = true }, "Password1.").RunSynchronously();
            }
        }
    }
}
