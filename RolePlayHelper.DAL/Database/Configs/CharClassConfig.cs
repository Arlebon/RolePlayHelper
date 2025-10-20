using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RolePlayHelper.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.DAL.Database.Configs
{
    internal class CharClassConfig : IEntityTypeConfiguration<CharClass>
    {
        public void Configure(EntityTypeBuilder<CharClass> builder)
        {
            builder.ToTable("Character_Class")
                .HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.HasMany(cl => cl.Characters)
                .WithMany(cha => cha.classes)
                .UsingEntity(j => j.ToTable("Character_Class_Link"));

            builder.HasOne(cl => cl.ParentClass)
                .WithMany(pcl => pcl.SubClasses)
                .HasForeignKey(cl => cl.ParentClassId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
