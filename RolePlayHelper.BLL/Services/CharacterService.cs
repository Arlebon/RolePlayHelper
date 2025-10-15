using RolePlayHelper.BLL.Exceptions.Character;
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
        public CharacterService(CharacterRepository characterRepository)  
        {
            _characterRepository = characterRepository;
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
            
            // Modifying stats here...

            _characterRepository.Add(character);
        }
    }
}
