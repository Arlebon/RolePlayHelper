namespace RolePlayHelper.API.Models.RaceTrait
{
    public class RaceTraitListDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public List<string> Races { get; set; } = new();

    }
}
