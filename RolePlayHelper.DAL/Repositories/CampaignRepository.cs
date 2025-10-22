using EntityToolBox;
using Microsoft.EntityFrameworkCore;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.DAL.Repositories
{
    public class CampaignRepository : BaseRepository<Campaign>
    {
        public CampaignRepository(RolePlayHelperContext context) : base(context) 
        {

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
