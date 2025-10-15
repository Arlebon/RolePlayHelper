using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions
{
    public abstract class NotFoundException : RolePlayHelperException
    {
        public NotFoundException(object content): base(404, content)
        {

        }
    }
}
