namespace RolePlayHelper.API.Models.Language
{
    public class LanguageListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<string> Races { get; set; } = null!;
    }
}
