using EntityToolBox;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Repositories
{
    public class RaceTraitRepository : BaseRepository<RaceTrait>
    {
        public RaceTraitRepository(RolePlayHelperContext context) : base(context)
        {
        }

        public RaceTrait? GetByName(string name)
        {
            return _set.FirstOrDefault(t => t.Name == name);
        }
    }
}
