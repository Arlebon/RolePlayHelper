using EntityToolBox;
using Microsoft.EntityFrameworkCore;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Repositories
{
    public class CharacterRepository : BaseRepository<Character>
    {
        public CharacterRepository(RolePlayHelperContext context) : base(context)
        {
        }

        public override IEnumerable<Character> GetAll()
        {
            return _set
                .Include(c => c.Classes)
                .Include(c => c.Race)
                .ToList();
        }  


        public bool ExistByName(string name)
        {
            return _set.Any(c => c.Name == name);
        }
    }
}
