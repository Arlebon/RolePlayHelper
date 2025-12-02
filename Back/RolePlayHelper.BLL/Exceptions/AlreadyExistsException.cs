using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions
{
    public abstract class AlreadyExistsException : RolePlayHelperException
    {
        public AlreadyExistsException(object content) : base(409, content)
        {

        }
    }
}
