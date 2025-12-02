using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.RaceTrait
{
    public class RaceTraitAlreadyExistsException : AlreadyExistsException
    {
        public RaceTraitAlreadyExistsException(string message) : base(message)
        {

        }

        public RaceTraitAlreadyExistsException() : base("Race trait already exists")
        {

        }
    }
}
