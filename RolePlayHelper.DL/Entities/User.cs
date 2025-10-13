using RolePlayHelper.DL.Enum;

namespace RolePlayHelper.DL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Role Role { get; set; }

    }
}