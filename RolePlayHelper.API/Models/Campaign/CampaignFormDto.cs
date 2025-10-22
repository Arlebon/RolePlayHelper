using System.ComponentModel.DataAnnotations;

namespace RolePlayHelper.API.Models.Campaign
{
    public class CampaignFormDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(2, 8)]
        public int MaxCharNb { get; set; }
    }
}
