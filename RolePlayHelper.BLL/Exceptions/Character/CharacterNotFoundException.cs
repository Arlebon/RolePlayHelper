namespace RolePlayHelper.BLL.Exceptions.Character
{
    public class CharacterNotFoundException : NotFoundException
    {
        public CharacterNotFoundException(string message) : base(message)
        {
        }

        public CharacterNotFoundException(int id) : base($"Character with id {id} not found") { }

        public CharacterNotFoundException() : base("Character not found.") { }
    }
}
