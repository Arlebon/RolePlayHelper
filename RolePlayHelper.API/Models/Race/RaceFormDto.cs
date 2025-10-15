using RolePlayHelper.API.Models.Language;
using RolePlayHelper.API.Models.RaceTrait;
using RolePlayHelper.API.Models.StatModifier;

namespace RolePlayHelper.API.Models.Race
{
    public class RaceFormDto
    {

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public StatModfierFormDto StatModifier { get; set; } = null!;

        public List<RaceTraitFormDto> Traits { get; set; }= new();

        public List<LanguageFormDto> Languages { get; set; } = new();

    }
}

