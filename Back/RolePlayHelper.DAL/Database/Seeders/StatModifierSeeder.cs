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
                WIS = 0,
                CHA = 0,
                CON = 0,
                INT = 0,
                SpellAttack = 0,
                SpellSave = 0,
                ArmorClass = 0,
                HitModifier = 0,
                Initiative = 0,
                MaxHP = 0,
                MVT = 0,

            });
        }
    }
}
