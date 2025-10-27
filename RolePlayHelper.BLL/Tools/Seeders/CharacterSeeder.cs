using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RolePlayHelper.BLL.Services;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Seeders
{
    public static class CharacterSeeder
    {
        public static void SeedDefaultCharacter(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var characterService = scope.ServiceProvider.GetRequiredService<CharacterService>();
            //var languageService = scope.ServiceProvider.GetRequiredService<LanguageService>();
            //var raceTraitService = scope.ServiceProvider.GetRequiredService<RaceTraitService>();
            //var charClassService = scope.ServiceProvider.GetRequiredService<CharClassService>();

            characterService.GetOrCreateDefault();

            User? defaultUser = context.Users.FirstOrDefault(u => u.UserName == "default");
            if (defaultUser == null)
            {
                return;
            }

            Language defaultLanguage = SeederHelper.GetOrGenerateDefault(
                context.Languages,
                l => l.Name == "default",
                () => new Language { Name = "default" },
                context);

            RaceTrait defaultRaceTrait = SeederHelper.GetOrGenerateDefault(
                context.RaceTraits,
                rt => rt.Name == "default",
                () => new RaceTrait
                {
                    Name = "default",
                    Description = "default Racetrait for default Race.",
                },
                context);

            Race defaultRace = SeederHelper.GetOrGenerateDefault(
                context.Races,
                r => r.Name == "default",
                () => new Race()
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
                },
                context);

            CharClass defaultClass = SeederHelper.GetOrGenerateDefault(
                context.Classes,
                cl => cl.Name == "default",
                () => new CharClass()
                {
                    ParentClassId = null,
                    Name = "default",
                    Description = "default Class for default Character",
                },
                context);

            Character defaultCharacter = SeederHelper.GetOrGenerateDefault(
                context.Characters,
                c => c.Name == "default Character",
                () => new Character()
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
                },
                context);
        }
    }
}
