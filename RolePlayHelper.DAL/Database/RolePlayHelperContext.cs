using Microsoft.EntityFrameworkCore;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Database
{
    public class RolePlayHelperContext: DbContext
    {
        public RolePlayHelperContext(DbContextOptions<RolePlayHelperContext> options) : base(options) 
        {

        }
        public DbSet<CharClass> Classes { get; set; }
        public DbSet<Character> Characters{ get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Race> Races { get; set; }

        public DbSet<StatModifier> StatModifiers { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RolePlayHelperContext).Assembly);
        }
    }
}
