using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.DL.Entities
{
    public class StatModifier
    {
        public int Id { get; set; }

        public int STR { get; set; }

        public int DEX { get; set; }

        public int CHA { get; set; }

        public int INT { get; set; }

        public int CON { get; set; }

        public int WIS { get; set; }

        public int MVT { get; set; }

        public int MaxHP { get; set; }

        public int ArmorClass { get; set; }

        public int HitModifier { get; set; }

        public int Initiative { get; set; }

        public int SpellAttack { get; set; }

        public int SpellSave { get; set; }
    }
}
