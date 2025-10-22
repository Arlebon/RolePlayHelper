namespace RolePlayHelper.API.Models.Character
{
    public class CharacterListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string RaceName { get; set; } = null!;

        public List<string> ClassNames { get; set; } = new();

    }
}
