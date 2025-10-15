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
    public class LanguageRepository : BaseRepository<Language>
    {
        public LanguageRepository(RolePlayHelperContext context) : base(context)
        {
        }
    }
}
