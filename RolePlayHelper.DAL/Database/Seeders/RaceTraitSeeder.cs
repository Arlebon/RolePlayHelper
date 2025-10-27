using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Database.Seeders
{
    public class RaceTraitSeeder : IEntityTypeConfiguration<RaceTrait>
    {
        public void Configure(EntityTypeBuilder<RaceTrait> builder)
        {
            builder.HasData(new RaceTrait
            {
                Id = 1,
                Name = "Darkvision",
                Description = "Can see in the dark up to 60 ft",
            });
        }
    }
}
