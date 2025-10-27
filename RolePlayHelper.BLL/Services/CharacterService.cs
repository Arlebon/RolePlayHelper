using RolePlayHelper.BLL.Exceptions.Character;
using RolePlayHelper.BLL.Tools;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DAL.Seeders;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.BLL.Services
{
    public class CharacterService 
    {
        private readonly CharacterRepository _characterRepository;
        private readonly RaceService _raceService;
        private readonly CharClassRepository _charClassRepository;
        private readonly LanguageService _languageService;
        private readonly UserService _userService;
        private readonly RaceTraitService raceTraitService;

        public CharacterService(
            CharClassRepository charClassRepository, 
            CharacterRepository characterRepository, 
            RaceService raceService,
)  
        {
            _characterRepository = characterRepository;
            _raceService = raceService;
            _charClassRepository = charClassRepository;
            _
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

        public bool ExistByUserId(int userId)
        {
            return _characterRepository.ExistByUserId(userId);
        }

        public Character? GetOne(int characterId)
        {
            Character? character = _characterRepository.GetOne(characterId);
            if (character == null)
            {
                throw new CharacterNotFoundException(characterId);
            }
            return character;
        }

        public void GetOrCreateDefault()
        {
            User? defaultUser = context.Users.FirstOrDefault(u => u.UserName == "default");
            if (defaultUser == null)
            {
                return;
            }

            Language defaultLanguage = SeederHelper.GetOrGenerateDefault(
                context.Languages,
                l => l.Name == "default",
                () => new Language { Name = "default" },
                context);

            RaceTrait defaultRaceTrait = SeederHelper.GetOrGenerateDefault(
                context.RaceTraits,
                rt => rt.Name == "default",
                () => new RaceTrait
                {
                    Name = "default",
                    Description = "default Racetrait for default Race.",
                },
                context);

            Race defaultRace = SeederHelper.GetOrGenerateDefault(
                context.Races,
                r => r.Name == "default",
                () => new Race()
                {
                    Name = "default",
                    Description = "this is a default Race for a default Character used by a default User.",
                    StatModifier = new()
                    {
                        STR = 5,
                        INT = -2,
                    },
                    Languages = new List<Language> { defaultLanguage },
                    Traits = new List<RaceTrait> { defaultRaceTrait },
                },
                context);

            CharClass defaultClass = SeederHelper.GetOrGenerateDefault(
                context.Classes,
                cl => cl.Name == "default",
                () => new CharClass()
                {
                    ParentClassId = null,
                    Name = "default",
                    Description = "default Class for default Character",
                },
                context);

            Character defaultCharacter = SeederHelper.GetOrGenerateDefault(
                context.Characters,
                c => c.Name == "default Character",
                () => new Character()
                {
                    Name = "default Character",
                    STR = 10,
                    CHA = 10,
                    DEX = 10,
                    WIS = 10,
                    CON = 10,
                    INT = 10,
                    Race = defaultRace,
                    User = defaultUser,
                    Classes = new List<CharClass> { defaultClass },
                },
                context);
        }

    }
}
