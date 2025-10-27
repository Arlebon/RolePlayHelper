using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Seeders
{
    public static class CharacterSeeder
    {
        public static void SeedDefaultCharacter(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<RolePlayHelperContext>();

            User? defaultUser = context.Users.FirstOrDefault(u => u.UserName == "default");
            if (defaultUser == null)
            {
                return;
            }

            Language? defaultLanguage = context.Languages.FirstOrDefault(l => l.Name == "default");
            if (defaultLanguage == null)
            {
                defaultLanguage = new Language
                {
                    Name = "default"
                };
                context.Languages.Add(defaultLanguage);
                context.SaveChanges();
            }

            RaceTrait? defaultRaceTrait = context.RaceTraits.FirstOrDefault(rt => rt.Name == "default");
            if (defaultRaceTrait == null)
            {
                defaultRaceTrait = new RaceTrait()
                {
                    Name = "default",
                    Description = "default Racetrait for default Race.",
                };
                context.Add(defaultRaceTrait);
                context.SaveChanges();
            }

            Race? defaultRace = context.Races.FirstOrDefault(r => r.Name == "default");
            if (defaultRace == null)
            {
                defaultRace = new Race
                {
                    Name = "default",
                    Description = "this is a default Race for a default Character used by a default User.",
                    StatModifier = new()
                    {
                        STR = 5,
                        INT = -2,
                    },
                    Languages = new List<Language> { defaultLanguage },
                    Traits = new List<RaceTrait> { defaultRaceTrait },
                };
                context.Races.Add(defaultRace);
                context.SaveChanges();
            }

            CharClass? defaultClass = context.Classes.FirstOrDefault(cl => cl.Name == "default");
            if (defaultClass == null)
            {
                defaultClass = new()
                {
                    ParentClassId = null,
                    Name = "default",
                    Description = "default Class for default Character",
                };
                context.Classes.Add(defaultClass);
                context.SaveChanges();
            }

            Character? defaultCharacter = context.Characters.FirstOrDefault(c => c.Name == "default");
            if (defaultCharacter == null)
            {
                defaultCharacter = new Character()
                {
                    Name = "default Character",
                    STR = 10,
                    CHA = 10,
                    DEX = 10,
                    WIS = 10,
                    CON = 10,
                    INT = 10,
                    Race = defaultRace,
                    User = defaultUser,
                    Classes = new List<CharClass> { defaultClass },
                    CampaignId = null,
                    IsPublic = true,
                    CurrentCampaign = null,
                };
            }
            context.Add(defaultCharacter);
            context.SaveChanges();
        }
    }
}
