using RolePlayHelper.API.Models.Race;
using System.ComponentModel.DataAnnotations;

namespace RolePlayHelper.API.Models.Character
{
    public class CharacterFormDto
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public int RaceId { get; set; }

        [Required]
        public int STR { get; set; }
        [Required]
        public int DEX { get; set; }
        [Required]
        public int CHA {  get; set; }
        [Required]
        public int INT { get; set; }
        [Required]
        public int CON {  get; set; }
        [Required]
        public int WIS { get; set; }
    }
}
