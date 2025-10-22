using RolePlayHelper.DL.Enums;

namespace RolePlayHelper.DL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public Role Role { get; set; }

        public List<Character> Characters { get; set; } = new();
    }
}
