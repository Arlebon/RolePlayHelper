using RolePlayHelper.API.Models.StatModifier;

namespace RolePlayHelper.API.Models.Race
{
    public class RaceFormDto
    {

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public StatModfierFormDto StatModifier { get; set; } = null!;

    }
}

