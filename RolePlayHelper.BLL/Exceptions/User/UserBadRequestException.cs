using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.User
{
    internal class UserBadRequestException : BadRequestException
    {
        public UserBadRequestException(string message) : base(message)
        {

        }

        public UserBadRequestException() : base("Login failed")
        {

        }
    }
}
