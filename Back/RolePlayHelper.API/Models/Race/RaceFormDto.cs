using RolePlayHelper.API.Models.Language;
using RolePlayHelper.API.Models.RaceTrait;
using RolePlayHelper.API.Models.StatModifier;
using System.ComponentModel.DataAnnotations;

namespace RolePlayHelper.API.Models.Race
{
    public class RaceFormDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = null!;

        public StatModfierFormDto StatModifier { get; set; } = null!;

        public List<int> Traits { get; set; } = null!;

        public List<int> Languages { get; set; } = null!;

    }
}

