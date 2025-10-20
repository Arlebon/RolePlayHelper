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
                SubClasses = character.Classes.Where(c => c.ParentClassId != null).Select(c => c.Name).ToList(),

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
                SubClassIds = form.SubClassIds,
                SubClasses = new List<CharClass>(),
            };
        }
    }
}
