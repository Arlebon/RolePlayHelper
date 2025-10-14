using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.DL.Entities
{
    internal class RaceTrait
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public Dictionary<int StatModifyer, int Value> StatModifiers { get; set; }

    }
}
