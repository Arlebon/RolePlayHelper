using RolePlayHelper.BLL.Exceptions.Character;
using RolePlayHelper.BLL.Tools;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Services
{
    public class CharacterService
    {
        private readonly CharacterRepository _characterRepository;
        private readonly RaceService _raceService;
        public CharacterService(CharacterRepository characterRepository, RaceService raceService)  
        {
            _characterRepository = characterRepository;
            _raceService = raceService;
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
            
            if(character.Race.StatModifier != null)
            {
                CharacterTool.ApplyStatModifier(character, character.Race.StatModifier);
            }

            _characterRepository.Add(character);
        }
    }
}
