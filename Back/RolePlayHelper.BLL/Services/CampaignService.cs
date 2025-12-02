using RolePlayHelper.BLL.Exceptions;
using RolePlayHelper.BLL.Exceptions.Campaign;
using RolePlayHelper.BLL.Exceptions.Character;
using RolePlayHelper.BLL.Exceptions.User;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.BLL.Services
{
    public class CampaignService
    {
        private readonly CampaignRepository _campaignRepository;
        private readonly CharacterService _characterService;
        private readonly UserService _userService;

        public CampaignService(CharacterService characterService, CampaignRepository campaignRepository, UserService userService)
        {
            _campaignRepository = campaignRepository;
            _characterService = characterService;
            _userService = userService;
        }

        public Campaign GetOne(int id)
        {
            Campaign? campaign = _campaignRepository.GetOne(id);

            if (campaign == null)
            {
                throw new CampaignNotFoundException($"Campaign with ID {id} not found");
            }

            return campaign;
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

        public void ChangeGM(int campaignId, int userId)
        {
            User newGM = _userService.GetOne(userId);
            Campaign current = GetOne(campaignId);
            bool userFound = false;

            List<int> participatingUsers = _campaignRepository.GetUserIdByCampaign(campaignId);

            participatingUsers.ForEach(u =>
            {
                if (u == userId)
                {
                    userFound = true;
                }
            });

            if (!userFound)
            {
                throw new UserNotInCampaignException($"User with ID {userId} not in the campaign with ID {campaignId}");
            }

            current.GM = newGM;
            current.GMId = userId;

            _campaignRepository.Update(current);
        }

        public bool IsGM(int campaignId, int userId)
        {
            Campaign campaign = GetOne(campaignId);

            return campaign.GMId == userId;
        }
    }
}
