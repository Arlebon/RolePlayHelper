using EntityToolBox;
using Microsoft.EntityFrameworkCore;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Repositories
{
    public class CharClassRepository : BaseRepository<CharClass>
    {
        public CharClassRepository(RolePlayHelperContext context) : base(context)
        {
        }
    }
}
