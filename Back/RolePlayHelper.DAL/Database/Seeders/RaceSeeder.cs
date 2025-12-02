using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Database.Seeders
{
    internal class RaceSeeder : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder.HasData(new Race
            {
                Id = 1,
                Name = "Human",
                Description = "Its a human, stupid!",
                StatModifierId = 1,
            });


        }
    }
}
