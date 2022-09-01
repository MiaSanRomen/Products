using Microsoft.AspNetCore.Identity;
using Products.Configurations;
using Products.Data.Models;

namespace Products.Data.Configuration
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "Administrator@mail.ru";
            string adminName = "Administrator";
            string adminPassword = "Admin111111!";
            string advancedEmail = "Advanced@mail.ru";
            string advancedName = "Advanced";
            string advancedPassword = "Advanced111111!";

            if (await roleManager.FindByNameAsync(CustomRoles.Administrator) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(CustomRoles.Administrator));
            }

            if (await roleManager.FindByNameAsync(CustomRoles.Advanced) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(CustomRoles.Advanced));
            }

            if (await roleManager.FindByNameAsync(CustomRoles.Simple) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(CustomRoles.Simple));
            }

            if (await userManager.FindByNameAsync(adminName) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminName, EmailConfirmed = true };
                IdentityResult resultAdmin = await userManager.CreateAsync(admin, adminPassword);
                if (resultAdmin.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, CustomRoles.Administrator);
                }
            }
                
            if (await userManager.FindByNameAsync(advancedName) == null)
            {
                User advanced = new User { Email = advancedEmail, UserName = advancedName, EmailConfirmed = true };
                IdentityResult resultAdvanced = await userManager.CreateAsync(advanced, advancedPassword);
                if (resultAdvanced.Succeeded)
                {
                    await userManager.AddToRoleAsync(advanced, CustomRoles.Advanced);
                }
            }
        }
    }
}
