using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.CharClass
{
    public class CharClassNotFoundException: NotFoundException
    {
        public CharClassNotFoundException(string message) : base(message) { }

        public CharClassNotFoundException(int id) : base($"Class with ID {id} not found") { }
    }
}
