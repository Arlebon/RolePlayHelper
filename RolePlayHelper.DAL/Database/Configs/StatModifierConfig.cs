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
    public class StatModifierConfig : IEntityTypeConfiguration<StatModifier>
    {
        public void Configure(EntityTypeBuilder<StatModifier> builder)
        {
            builder.ToTable("StatModifier");

            builder.HasKey(s => s.Id)
                .HasName("PK_StatModifier")
                .IsClustered();
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
