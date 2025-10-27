using Microsoft.Extensions.DependencyInjection;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.BLL
{
    public static class AppSeeder
    {
        public static void SeedDefaultCharacter(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<RolePlayHelperContext>();

            Character? defaultCharacter = context.Characters.FirstOrDefault(c => c.Name == "Default Character");

            if (defaultCharacter == null)
            {
                defaultCharacter = new Character()
                {
                    Name = "Default Character",
                    STR = 10,
                    INT = 10,
                    DEX = 10,
                    CON = 10,
                    CHA = 10,
                    WIS = 10,
                    Classes = new List<CharClass> { context.Classes.Find(1)?? throw new NotImplementedException()},
                    Race = context.Races.Find(1)?? throw new NotImplementedException(),
                    User = context.Users.Find(2)?? throw new NotImplementedException(),
                };
                context.Add(defaultCharacter);
                context.SaveChanges();
            }

        }
    }
}
