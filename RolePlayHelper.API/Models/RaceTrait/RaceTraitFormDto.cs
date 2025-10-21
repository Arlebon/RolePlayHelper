using System.ComponentModel.DataAnnotations;

namespace RolePlayHelper.API.Models.RaceTrait
{
    public class RaceTraitFormDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

    }
}
