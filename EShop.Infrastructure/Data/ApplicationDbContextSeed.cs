using EShop.ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories());
                context.SaveChanges();

            }

            if (!userManager.Users.Any())
            {
                await userManager.CreateAsync(
                    new ApplicationUser
                    {
                        Email = "yigith1@gmail.com",
                        UserName = "yigith1@gmail.com",
                        EmailConfirmed = true
                    },
                    "Password1."
                );
            }
        }

        private static readonly Random rnd = new Random();
        public static List<Category> Categories(int count = 5, int productCountPerCategory = 99)
        {
            var categories = new List<Category>();
            var pid = 1;

            for (int i = 1; i <= count; i++)
            {
                var category = new Category 
                { 
                    CategoryName = "Category " + i,
                    Products = new List<Product>()
                };

                for (int j = 0; j < productCountPerCategory; j++)
                {
                    category.Products.Add(
                        new Product
                        {
                            CategoryId = i,
                            ProductName = "Product " + pid,
                            UnitPrice = rnd.Next(1, 11) * 10.00m
                        }
                    );
                    pid++;
                }

                categories.Add(category);
            }

            return categories;
        }

        public static List<Product> Products(int categoryCount = 5, int productCountPerCategory = 99)
        {
            var products = new List<Product>();
            var pid = 1;
            for (int i = 1; i <= categoryCount; i++)
            {
                for (int j = 0; j < productCountPerCategory; j++)
                {
                    products.Add(
                        new Product
                        {
                            Id = pid,
                            CategoryId = i,
                            ProductName = "Product " + pid,
                            UnitPrice = 0
                        }
                    );
                    pid++;
                }
            }

            return products;
        }
    }
}
