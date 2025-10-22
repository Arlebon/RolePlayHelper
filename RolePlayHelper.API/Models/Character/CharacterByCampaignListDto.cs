namespace RolePlayHelper.API.Models.Character
{
    public class CharacterByCampaignListDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Race { get; set; } = null!;

        public List<string> Classes { get; set; } = new List<string>();
    }
}
