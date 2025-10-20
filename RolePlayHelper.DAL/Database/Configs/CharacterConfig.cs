using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Database.Configs
{
    public class CharacterConfig : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("Character");

            builder.HasKey(c => c.Id)
                .HasName("PK_Character")
                .IsClustered();
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.HasOne(c => c.Race)
                .WithMany(r => r.Characters)
                .HasForeignKey(c => c.RaceId);

            builder.HasMany(c => c.Classes)
                .WithMany(cl => cl.Characters);
        }
    }
}
