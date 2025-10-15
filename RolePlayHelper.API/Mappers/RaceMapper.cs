using RolePlayHelper.API.Models.Race;
using RolePlayHelper.API.Models.StatModifier;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Mappers
{
    public static class RaceMapper
    {
        public static RaceIndexDto ToRaceIndexDto(this Race race)
        {
            return new RaceIndexDto()
            {
                Name = race.Name,
            };
        }

        public static Race ToRace(this RaceFormDto form)
        {
            return new Race()
            {
                Name = form.Name,
                Description = form.Description,
                StatModifier = form.StatModifier.ToStatModifier(),

                // Pour chaque entré dans Langues je crée une nouvelle entité Langue.
                Languages = form.Languages.Select(l => new Language { Name = l.Name }).ToList(),


                // Pour chaque entré dans Traits je crée une nouvelle entité RaceTrait.
                Traits = form.Traits.Select(t => new RaceTrait{
                    Name = t.Name,
                    Description = t.Description,
                }).ToList()
            };
        }
    }
}
