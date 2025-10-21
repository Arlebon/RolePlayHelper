using RolePlayHelper.DL.Enums;
using System.ComponentModel.DataAnnotations;

namespace RolePlayHelper.API.Models.User
{
    public class UserRegisterFormDto
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = null!;



        [Required] // Ajouter des décorateurs (length, emailadress, etc)
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        // Pas besoin de vérif mail/mdp dans le back, juste côté front

        [Required]
        public string Password { get; set; } = null!;
    }
}
