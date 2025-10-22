using RolePlayHelper.API.Models.Campaign;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Mappers
{
    public static class CampaignMapper
    {
        public static Campaign ToCampaign(this CampaignFormDto form)
        {
            return new Campaign()
            {
                Name = form.Name,
                MaxCharNb = form.MaxCharNb,
            };
        }
    }
}
