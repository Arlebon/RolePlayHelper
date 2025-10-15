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
    }
}
