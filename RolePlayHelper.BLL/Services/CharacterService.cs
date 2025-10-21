using RolePlayHelper.BLL.Exceptions.Character;
using RolePlayHelper.BLL.Tools;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.BLL.Services
{
    public class CharacterService
    {
        private readonly CharacterRepository _characterRepository;
        private readonly RaceService _raceService;
        private readonly CharClassRepository _charClassRepository;
        public CharacterService(CharClassRepository charClassRepository, CharacterRepository characterRepository, RaceService raceService)  
        {
            _characterRepository = characterRepository;
            _raceService = raceService;
            _charClassRepository = charClassRepository;
        }

        public List<Character> getAll()
        {
            return _characterRepository.GetAll().ToList();
        }

        public void Add(Character character)
        {
            if(_characterRepository.ExistByName(character.Name))
            {
                throw new CharacterAlreadyExistException($"Character with name {character.Name} already exists.");
            }

            character.Race = _raceService.GetOneById(character.RaceId);

            // TO VERIFY
            character.ClassIds.ForEach(cid =>
            {
                CharClass? charClass = _charClassRepository.GetOne(cid); // Utilisation du service plutôt que le repo, pour éviter le test si null
                if (charClass == null)
                {
                    throw new NotImplementedException();
                }
                character.Classes.Add(charClass);
            });

            character.SubClassIds.ForEach(sid =>
            {
                CharClass? charClass = _charClassRepository.GetOne(sid);
                if (charClass == null)
                {
                    throw new NotImplementedException();
                }
                character.Classes.Add(charClass);
            });

            if(character.Race.StatModifier != null)
            {
                CharacterTool.ApplyStatModifier(character, character.Race.StatModifier);
            }

            _characterRepository.Add(character);
        }
    }
}
