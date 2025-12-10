using RolePlayHelper.API.Models.Race;
using RolePlayHelper.API.Models.StatModifier;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Mappers
{
    public static class RaceMapper
    {
        public static RaceListDto ToRaceListDto(this Race race)
        {
            return new RaceListDto()
            {
                Id = race.Id,
                Name = race.Name,
                statModifier = race.StatModifier.ToStatModifierListDto()
            };
        }

        public static RaceListAddCharDto ToRaceListAddCharDto(this Race race)
        {
            return new RaceListAddCharDto()
            {
                Id = race.Id,
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
                Languages = form.Languages.Select(l => l.ToLanguage()).ToList(),


                // Pour chaque entré dans Traits je crée une nouvelle entité RaceTrait.
                Traits = form.Traits.Select(t => t.ToRaceTrait()).ToList()
            };
        }
    }
}
