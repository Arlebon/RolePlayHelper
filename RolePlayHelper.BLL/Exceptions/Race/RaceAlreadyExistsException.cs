using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.Race
{
    public class RaceAlreadyExistsException : AlreadyExistsException
    {
        public RaceAlreadyExistsException() : base("This race already exists")
        {

        }

        public RaceAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
