using Isopoh.Cryptography.Argon2;
using Microsoft.Extensions.DependencyInjection;
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
            var context = scope.ServiceProvider.GetRequiredService<RolePlayHelperContext>();

            bool adminExists = context.Users.Any(u => u.Role == Role.Admin);

            if (!adminExists)
            {
                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@rph.local",
                    Password = "123",
                    Role = Role.Admin
                };

                admin.Password = Argon2.Hash(admin.Password);

                context.Users.Add(admin);
                context.SaveChanges();
            }
        }

        public static void SeedUser(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<RolePlayHelperContext>();

            bool defaultUserExists = context.Users.Any(u => u.UserName == "default");

            if (!defaultUserExists)
            {
                User defaultUser = new User
                {
                    UserName = "default",
                    Password = "123",
                    Email = "default@web.be",
                    Role = DL.Enums.Role.User,
                };

                defaultUser.Password = Argon2.Hash(defaultUser.Password);

                context.Users.Add(defaultUser);
                context.SaveChanges();
            }
        }
    }
}
