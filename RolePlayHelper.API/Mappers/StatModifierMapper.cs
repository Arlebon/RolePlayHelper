using RolePlayHelper.API.Models.StatModifier;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Mappers
{
    public static class StatModifierMapper
    {
        public static StatModifier ToStatModifier(this StatModfierFormDto form)
        {
            return new StatModifier()
            {
                STR = form.STR,
                DEX = form.DEX,
                CHA = form.CHA,
                INT = form.INT,
                CON = form.CON,
                WIS = form.WIS,
                MVT = form. MVT,
                MaxHP = form.MaxHP,
                ArmorClass = form.ArmorClass,
                HitModifier = form.HitModifier,
                Initiative = form.Initiative,
                SpellAttack = form.SpellAttack,
                SpellSave = form.SpellSave,
            };
        }
    }
}
