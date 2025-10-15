using RolePlayHelper.DL.Enums;
using System.ComponentModel.DataAnnotations;

namespace RolePlayHelper.API.Models.User
{
    public class UserRegisterFormDto
    {
        [Required]
        public string Username { get; set; } = null!;



        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string EmailConfirmed { get; set; } = null!;



        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string PasswordVerification { get; set; } = null!;
    }
}
