namespace RolePlayHelper.API.Models.Character
{
    public class CharacterPublicListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string RaceName { get; set; } = null!;

        public List<string> ClassNames { get; set; } = new();

        public string? CampaignName { get; set; }
        public bool IsPublic { get; set; }

        public string UserName { get; set; }

    }
}
