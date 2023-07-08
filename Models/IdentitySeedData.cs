using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class IdentitySeedData
    {
        public static void CreateAdminAccount(IServiceProvider serviciceProvider, IConfiguration configuration)
        {
            CreateAdminAccountAsync(serviciceProvider, configuration).Wait();
        }

        public static async Task CreateAdminAccountAsync(IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            serviceProvider = serviceProvider.CreateScope().ServiceProvider;

            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var username = configuration["Data:AdminUser:Name"] ?? "admin";
            var email = configuration["Data:AdminUser:Email"] ?? "admin@example.com";
            var password = configuration["Data:AdminUser:Password"] ?? "secret";
            var role = configuration["Data:AdminUser:Role"] ?? "Admins";

            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                var user = new IdentityUser
                {
                    UserName = username,
                    Email = email
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
