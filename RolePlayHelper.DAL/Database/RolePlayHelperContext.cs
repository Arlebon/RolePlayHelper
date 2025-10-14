using Microsoft.EntityFrameworkCore;
using RolePlayHelper.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.DAL.Database
{
    public class RolePlayHelperContext: DbContext
    {
        public RolePlayHelperContext(DbContextOptions<RolePlayHelperContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RolePlayHelperContext).Assembly);
        }
    }
}
