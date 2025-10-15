using EntityToolBox;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Repositories
{
    public class LanguageRepository : BaseRepository<Language>
    {
        public LanguageRepository(RolePlayHelperContext context) : base(context)
        {
        }
    }
}
