using System.ComponentModel.DataAnnotations;

namespace RolePlayHelper.API.Models.Language
{
    public class LanguageFormDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
