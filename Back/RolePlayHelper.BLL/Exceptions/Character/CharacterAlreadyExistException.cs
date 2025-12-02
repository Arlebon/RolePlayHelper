using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.Character
{
    public class CharacterAlreadyExistException : AlreadyExistsException
    {
        public CharacterAlreadyExistException() : base("Character already exists") { }
        public CharacterAlreadyExistException(string message) : base(message)
        {
        }
    }
}
