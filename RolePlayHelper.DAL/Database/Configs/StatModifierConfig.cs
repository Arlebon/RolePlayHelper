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

            builder.Property(s => s.STR)
                .IsRequired(false);

            builder.Property(s => s.DEX)
                .IsRequired(false);

            builder.Property(s => s.CHA)
                .IsRequired(false);

            builder.Property(s => s.INT)
                .IsRequired(false);

            builder.Property(s => s.CON)
                .IsRequired(false);

            builder.Property(s => s.WIS)
                .IsRequired(false);

            builder.Property(s => s.MVT)
                .IsRequired(false);

            builder.Property(s => s.MaxHP)
                .IsRequired(false);

            builder.Property(s => s.ArmorClass)
                .IsRequired(false);

            builder.Property(s => s.HitModifier)
                .IsRequired(false);

            builder.Property(s => s.Initiative)
                .IsRequired(false);

            builder.Property(s => s.SpellAttack)
                .IsRequired(false);

            builder.Property(s => s.SpellSave)
                .IsRequired(false);
        }
    }
}
