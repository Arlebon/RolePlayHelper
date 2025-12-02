using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.Language
{
    public class LanguageAlreadyExistsException : AlreadyExistsException
    {
        public LanguageAlreadyExistsException(string message) : base(message)
        {

        }

        public LanguageAlreadyExistsException() : base("Language already exists")
        {

        }
    }
}
