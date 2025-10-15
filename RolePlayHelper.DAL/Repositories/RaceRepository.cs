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
    }
}
