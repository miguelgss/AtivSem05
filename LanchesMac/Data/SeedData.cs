using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace LanchesMac.Data
{
    public static class SeedData
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            // Perfis customizados
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Define as roles principais do projeto em um array de strings
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;

            // Percorre o array de strings, verificando se o perfil já existe
            foreach (var roleName in roleNames)
            {
                
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                // Cria os perfis e os inclui no BD
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Cria uma instância de um super usuário
            var poweruser = new IdentityUser
            {
                // Obtém o nome e email definidos no appsettings.json
                UserName = Configuration.GetSection("UserSettings")["UserName"],
                Email = Configuration.GetSection("UserSettings")["UserEmail"]
            };

            // Obtém a senha definida no appsettings.json
            string userPassword = Configuration.GetSection("UserSettings")["UserPassword"];

            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);

            if (user == null)
            {
                // Cria o super usuário com os dados informados
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    // Atribui o usuário ao perfil de Admin
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }
}
