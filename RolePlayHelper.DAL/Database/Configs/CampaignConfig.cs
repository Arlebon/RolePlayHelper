using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.DAL.Database.Configs
{
    public class CampaignConfig : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaign");

            builder.HasKey(c => c.Id)
                .HasName("PK_Campaign")
                .IsClustered();
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.HasMany(c => c.Characters)
                .WithOne(ch => ch.CurrentCampaign)
                .HasForeignKey(ch => ch.CampaignId);

            builder.HasOne(c => c.GM)
                .WithMany(u => u.CampaignsAsGM)
                .HasForeignKey(c => c.GMId);
        }
    }
}
