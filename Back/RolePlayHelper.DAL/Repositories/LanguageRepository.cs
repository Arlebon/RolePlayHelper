using EntityToolBox;
using Microsoft.EntityFrameworkCore;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Repositories
{
    public class LanguageRepository : BaseRepository<Language>
    {
        public LanguageRepository(RolePlayHelperContext context) : base(context)
        {
        }

        public Language? GetByName(string name)
        {
            return _set.FirstOrDefault(l => l.Name == name);
        }

        public override List<Language> GetAll()
        {
            return _set.Include(l => l.Races).ToList();
        }
    }
}
