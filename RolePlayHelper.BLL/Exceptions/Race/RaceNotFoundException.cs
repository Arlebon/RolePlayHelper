using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.Race
{
    public class RaceNotFoundException : NotFoundException
    {
        public RaceNotFoundException(): base("Race not found")
        {

        }

        public RaceNotFoundException(string message) : base(message)
        {

        }
    }
}
