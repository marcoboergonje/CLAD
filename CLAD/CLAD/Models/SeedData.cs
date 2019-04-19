using CLAD.Data;
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
                var existingAdmin = await userManager.FindByNameAsync("Admin@gmail.com");
                if (existingAdmin == null)
                {
                    var AdminEmail = "Admin@gmail.com";
                    var AdminPhonenumber = "0987665342";
                    var AdminPassword = "Admin1!";

                    IdentityUser AdminUser = new IdentityUser { UserName = AdminEmail, Email = AdminEmail, PhoneNumber = AdminPhonenumber };
                    await userManager.CreateAsync(AdminUser, AdminPassword);
                    await userManager.AddToRoleAsync(AdminUser, "Admin");
                }
                var existingConsultant = await userManager.FindByNameAsync("Consultant@gmail.com");
                if (existingConsultant == null)
                { 
                     var ConsultantEmail = "Consultant@gmail.com";
                     var ConsultantPhonenumber = "0987665342";
                     var ConsultantPassword = "Consultant1!";

                     IdentityUser ConsultantUser = new IdentityUser { UserName = ConsultantEmail, Email = ConsultantEmail, PhoneNumber = ConsultantPhonenumber };
                     await userManager.CreateAsync(ConsultantUser, ConsultantPassword);
                     await userManager.AddToRoleAsync(ConsultantUser, "Consultant");
               }
            }
        }
    }
}
