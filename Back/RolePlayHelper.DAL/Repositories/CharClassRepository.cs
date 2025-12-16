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

        public List<CharClass> GetSomeByName(string filter)
        {
            return _set.Where(c => c.Name.StartsWith(filter)).ToList();
        }
    }
}
