using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.StatModifier
{
    public class StatModifierNotFoundException : NotFoundException
    {
        public StatModifierNotFoundException(string message) : base(message)
        {

        }

        public StatModifierNotFoundException() : base("Stat modifier not found")
        {

        }
    }
}
