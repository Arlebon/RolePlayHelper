using EntityToolBox;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Repositories
{
    public class CharacterRepository : BaseRepository<Character>
    {
        public CharacterRepository(RolePlayHelperContext context) : base(context)
        {
        }

        public bool ExistByName(string name)
        {
            return _set.Any(c => c.Name == name);
        }
    }
}
