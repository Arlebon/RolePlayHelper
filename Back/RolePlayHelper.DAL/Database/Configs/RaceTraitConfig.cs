using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Database.Configs
{
    public class RaceTraitConfig : IEntityTypeConfiguration<RaceTrait>
    {
        public void Configure(EntityTypeBuilder<RaceTrait> builder)
        {
            builder.ToTable("RaceTrait");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(r => r.Name)
                .IsUnique();
        }
    }
}
