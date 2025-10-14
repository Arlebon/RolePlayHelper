using RolePlayHelper.API.Models;
using RolePlayHelper.DL.Entities;

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
                Username = user.Username,
            };
        }
    }
}
