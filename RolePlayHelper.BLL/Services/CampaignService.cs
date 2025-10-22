using RolePlayHelper.BLL.Exceptions.Campaign;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Services
{
    public class CampaignService
    {
        private readonly CampaignRepository _campaignRepository;

        public CampaignService(CampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public void Create(Campaign campaign, int gmId)
        {
            if (_campaignRepository.ExistByName(campaign.Name))
            {
                throw new CampaignAlreadyExistsException($"Campaign with the name {campaign.Name} already exists");
            }

            campaign.GMId = gmId;

            _campaignRepository.Add(campaign);
        }

        public List<Character> GetCharactersByCampaign(int id)
        {
            if (_campaignRepository.GetOne(id) == null)
            {
                throw new CampaignNotFoundException($"Campaing with ID {id} not found");
            }

            return _campaignRepository.GetCharactersByCampaign(id);
        }
    }
}
