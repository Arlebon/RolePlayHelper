using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions
{
    public abstract class RolePlayHelperException : Exception
    {
        public int StatusCode { get; set; }

        public object Content { get; set; } = null!;

        public RolePlayHelperException(int statusCode, object content)
        {
            StatusCode = statusCode;
            Content = content;
        }
    }
}
