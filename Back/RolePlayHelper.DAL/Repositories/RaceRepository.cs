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
    public class RaceRepository : BaseRepository<Race>
    {
        public RaceRepository(RolePlayHelperContext context) : base(context)
        {
        }

        public bool ExistByName(string name)
        {
            return _set.Any(r => r.Name == name);
        }

        public override Race? GetOne(int id)
        {
            return _set.Include(r => r.StatModifier).Include(r => r.Languages).Include(r => r.Traits).FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Race> GetAllWithStatModifier()
        {
            return _set.Include(sm => sm.StatModifier).ToList();
        }
    }
}