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

        public List<Character> GetAll()
        {
            return _characterRepository.GetAll().ToList();
        }

        public List<Character> GetAllByUserId(int userId)
        {
            if (!_characterRepository.ExistByUserId(userId))
            {
                throw new CharacterNotFoundException($"No Character for User with ID {userId} found.");
            }
            return _characterRepository.GetAllByUserId(userId).ToList();
        }

        public void Add(int userId, Character character)
        {
            if(_characterRepository.ExistByName(character.Name))
            {
                throw new CharacterAlreadyExistException($"Character with name {character.Name} already exists.");
            }

            character.UserId = userId;
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

            if(character.Race.StatModifier != null)
            {
                CharacterTool.ApplyStatModifier(character, character.Race.StatModifier);
            }

            _characterRepository.Add(character);
        }

        public void UpdateVisibilty(int id, bool isPublic)
        {
            Character? character = _characterRepository.GetOne(id);
            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }

            character.IsPublic = isPublic;

            _characterRepository.Update(character);
        }

        internal bool ExistByUserId(int userId)
        {
            return _characterRepository.ExistByUserId(userId);
        }

        internal Character? GetOne(int characterId)
        {
            Character? character = _characterRepository.GetOne(characterId);
            if (character == null)
            {
                throw new CharacterNotFoundException(characterId);
            }
            return character;
        }
    }
}
