using System.ComponentModel.DataAnnotations;

namespace RolePlayHelper.API.Models.Language
{
    public class LanguageFormDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}
