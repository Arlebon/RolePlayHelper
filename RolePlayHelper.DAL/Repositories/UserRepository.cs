using EntityToolBox;
using Microsoft.EntityFrameworkCore;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(RolePlayHelperContext context) : base(context)
        {
        }

        public bool ExistByEmail(string email)
        {
            return _set.Any(u => u.Email == email);
        }

        public bool ExistByUsername(string username)
        {
            return _set.Any(u => u.Username == username);
        }


        public User? GetPasswordByUsernameOrMail(string login)
        {
            User? user = _set.FirstOrDefault(u => u.Username == login || u.Email == login);
            return user;
        }
    }
}
