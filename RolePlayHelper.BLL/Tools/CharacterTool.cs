using RolePlayHelper.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Tools
{
    public static class CharacterTool
    {
        public static void ApplyStatModifier(Character character, StatModifier modifier)
        {
            var statModifierProperties = typeof(StatModifier).GetProperties()
                .Where(p => p.PropertyType == typeof(int?) && p.Name != "Id");

            foreach (var prop in statModifierProperties)
            {
                int value = (int)prop.GetValue(modifier)!;

                if (value != 0)
                {
                    var charProp = typeof(Character).GetProperty(prop.Name);
                    
                    if(charProp != null && charProp.PropertyType == typeof(int))
                    {
                        int baseValue = (int)charProp.GetValue(character)!;
                        charProp.SetValue(character, baseValue + value);
                    }
                }
            }
        }
    }
}
