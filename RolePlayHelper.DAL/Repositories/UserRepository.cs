using EntityToolBox;
using Microsoft.EntityFrameworkCore;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Repositories
{
    internal class UserRepository : BaseRepository<User>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
