using RolePlayHelper.BLL.Exceptions;
using RolePlayHelper.BLL.Exceptions.Campaign;
using RolePlayHelper.BLL.Exceptions.Character;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.BLL.Services
{
    public class CampaignService
    {
        private readonly CampaignRepository _campaignRepository;
        private readonly CharacterService _characterService;

        public CampaignService(CharacterService characterService, CampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
            _characterService = characterService;
        }

        public void AddCharacterToCampaign(int userId, int campaginId, int characterId)
        {

            Character character = _characterService.GetOne(characterId)!;

            //// Check si character appartient au User (should be done by frontend?)
            //if (character.UserId != userId)
            //{
            //    // TO DO Custom Exception
            //    throw new UnauthorizedAccessException();
            //}

            Campaign campaign = _campaignRepository.GetOne(campaginId) ?? throw new CampaignAlreadyExistsException(); // TO DO CUSTOM NOT FOUND HERE!!!

            _campaignRepository.AddCharacterToCampaign(character, campaign);

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
