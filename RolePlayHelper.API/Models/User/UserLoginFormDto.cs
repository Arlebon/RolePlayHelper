using System.ComponentModel.DataAnnotations;

namespace RolePlayHelper.API.Models.User
{
    public class UserLoginFormDto
    {
        [Required]
        [MaxLength(255)]
        public string Login { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
