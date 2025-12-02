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

        public override List<Character> GetAll()
        {
            return _set
                .Include(c => c.Classes)
                .Include(c => c.Race)
                .ToList();
        }

        public List<Character> GetAllByUserId(int userId)
        {
            return _set
                .Where(c => c.UserId == userId)
                .Include(c => c.Classes)
                .Include(c => c.Race)
                .Include(c => c.CurrentCampaign)
                .ToList();
        }


        public bool ExistByName(string name)
        {
            return _set.Any(c => c.Name == name);
        }

        public bool ExistByUserId(int userId)
        {
            return _set.Any(c => c.UserId == userId);
        }
    }
}
