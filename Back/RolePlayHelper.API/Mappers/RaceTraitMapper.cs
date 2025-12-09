using RolePlayHelper.API.Models.RaceTrait;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Mappers
{
    public static class RaceTraitMapper
    {
        public static RaceTrait ToRaceTrait(this RaceTraitFormDto form)
        {
            return new RaceTrait()
            {
                Name = form.Name,
                Description = form.Description,
            };
        }

        public static RaceTraitListDto ToRaceTraitListDto(this RaceTrait rt)
        {
            return new RaceTraitListDto
            {
                Id = rt.Id,
                Description = rt.Description,
                Name = rt.Name,
                Races = rt.Races.Select(r => r.Name).ToList()
            };
        }
    }
}
