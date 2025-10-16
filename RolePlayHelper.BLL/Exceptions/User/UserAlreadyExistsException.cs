using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.User
{
    public class UserAlreadyExistsException : AlreadyExistsException
    {
        public UserAlreadyExistsException(string message) : base(message) 
        {

        }

        public UserAlreadyExistsException() : base("User already exists")
        {

        }
    }
}
