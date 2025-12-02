using RolePlayHelper.API.Models.Character;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Mappers
{
    public static class CharacterMapper
    {
        public static CharacterListDto ToCharacterListDto(this Character character)
        {
            return new CharacterListDto()
            {
                Id = character.Id,
                Name = character.Name,
                RaceName = character.Race.Name,
                ClassNames = character.Classes.Select(c => c.Name).ToList(),
                CampaignName = character.CurrentCampaign?.Name,
            };
        }

        public static Character ToCharacter(this CharacterFormDto form)
        {
            return new Character()
            {
                Name = form.Name,
                STR = form.STR,
                DEX = form.DEX,
                CHA = form.CHA,
                INT = form.INT,
                CON = form.CON,
                WIS = form.WIS,
                RaceId = form.RaceId,
                ClassIds = form.CharClassIds,
                Classes = new List<CharClass>(),
            };
        }

        public static CharacterByCampaignListDto ToCharacterByCampaignListDto(this Character character)
        {
            return new CharacterByCampaignListDto()
            {
                Id = character.Id,
                Name = character.Name,
                Race = character.Race.Name,
                Classes = character.Classes.Select(c => c.Name).ToList(),
            };
        }
    }
}
