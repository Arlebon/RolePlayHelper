using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Database.Seeders
{
    internal class ClassSeeder : IEntityTypeConfiguration<CharClass>
    {
        public void Configure(EntityTypeBuilder<CharClass> builder)
        {
            builder.HasData(new CharClass
            {
                Id = 1,
                Name = "Fighter",
                Description = "a basic fighter.",
                ParentClassId = null,
            });
        }
    }
}
