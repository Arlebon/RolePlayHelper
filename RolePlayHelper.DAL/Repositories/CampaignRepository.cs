using EntityToolBox;
using Microsoft.EntityFrameworkCore;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Repositories
{
    public class CampaignRepository : BaseRepository<Campaign>
    {
        public CampaignRepository(RolePlayHelperContext context) : base(context) 
        {

        }

        public void AddCharacterToCampaign(Character character, Campaign campaign)
        {
            character.CurrentCampaign = campaign;
            _context.Update(character);
            _context.SaveChanges();
        }

        public bool ExistByName(string name)
        {
            return _set.Any(c => c.Name == name);
        }

        public List<Character> GetCharactersByCampaign(int id)
        {
            return _set.Include(c => c.Characters)
                .Where(c => c.Id == id)
                .SelectMany(c => c.Characters)
                .ToList();
        }
    }
}
