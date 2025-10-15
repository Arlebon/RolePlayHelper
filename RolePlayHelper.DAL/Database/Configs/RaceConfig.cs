using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RolePlayHelper.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.DAL.Database.Configs
{
    public class RaceConfig : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder.ToTable("Race");

            builder.HasKey(r => r.Id)
                .HasName("PK_Race")
                .IsClustered();
            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(r => r.Name)
                .IsUnique();


            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(r => r.StatModifier)
                .WithOne(sm => sm.Race)
                .HasForeignKey<Race>(r => r.StatModifierId);
            
        }
    }
}
