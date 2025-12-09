using RolePlayHelper.API.Models.StatModifier;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Models.Race
{
    public class RaceListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public StatmodifierListDto statModifier { get; set; } = null!;

    }
}

