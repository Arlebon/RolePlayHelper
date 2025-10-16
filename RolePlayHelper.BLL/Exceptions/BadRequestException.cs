using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions
{
    public abstract class BadRequestException : RolePlayHelperException
    {
        public BadRequestException(object content) : base(400, content)
        {

        }
    }
}
