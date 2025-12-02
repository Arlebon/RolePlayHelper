namespace RolePlayHelper.API.Models.Character
{
    public class CharacterCampaignSubscriptionDto
    {   
        public int Id { get; set; } // If not null, character not available for subscription?
        public string Name { get; set; } = null!;
        public int CampaignId { get; set; }
    }
}
