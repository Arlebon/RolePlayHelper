using RolePlayHelper.API.Models.User;
using RolePlayHelper.DL.Entities;
using RolePlayHelper.DL.Enums;

namespace RolePlayHelper.API.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this UserRegisterFormDto user)
        {
            return new User()
            {
                Email = user.Email,
                Password = user.Password,
                UserName = user.Username,
                Role = Role.User,
            };
        }
    }
}
