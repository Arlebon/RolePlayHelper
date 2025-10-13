using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this User user)
        {
            return new User()
            {
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Username = user.Username,
            };
        }
    }
}
