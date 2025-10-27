using Isopoh.Cryptography.Argon2;
using Microsoft.Extensions.DependencyInjection;
using RolePlayHelper.BLL.Services;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;
using RolePlayHelper.DL.Enums;


namespace RolePlayHelper.Seeders
{
    public static class UserSeeder
    {
        public static void SeedAdminUser(IServiceProvider serviceProvider) //ISerivceProvider = conteneur qui store les services qu'on rajoute dans programme (?)
        {

            // On doit simular une réquète HTTP afin d'utiliser les services scoped. 
            // Using nous rassure que cette requete est disposé proprement à la fin de son utilisation
            using var scope = serviceProvider.CreateScope();

            // On récupère une instance de notre DbContext via notre requète artificielle 'scope'
            // Cela nous permet de simulezr un comportement normale de notre requete HTTP
            var userService = scope.ServiceProvider.GetRequiredService<UserService>();

            userService.GetOrCreateAdmin();

            userService.GetOrCreateDefaultUser();
            
        }
    }
}
