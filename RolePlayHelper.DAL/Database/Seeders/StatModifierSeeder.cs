using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Database.Seeders
{
    internal class StatModifierSeeder : IEntityTypeConfiguration<StatModifier>
    {
        public void Configure(EntityTypeBuilder<StatModifier> builder)
        {
            builder.HasData(new StatModifier
            {
                Id = 1,
                STR = 2,
                DEX = 1,
            });
        }
    }
}
