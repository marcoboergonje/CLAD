﻿using CLAD.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLAD.Models
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

            }
            using (var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>())
            {
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                if (!await roleManager.RoleExistsAsync("Consultant"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Consultant"));
                }
                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }

            }


            using (var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>())
            {
                var existingUser = await userManager.FindByNameAsync("dennie@gmail.com");
                if (existingUser == null )
                {
                    var email = "dennie@gmail.com";
                    var phonenumber = "0987665342";
                    var password = "Weetikniet1!";

                    IdentityUser user = new IdentityUser { UserName = email, Email = email, PhoneNumber = phonenumber };
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
