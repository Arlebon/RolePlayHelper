
using RolePlayHelper.BLL.Exceptions.CharClass;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.BLL.Services
{
    public class CharClassService
    {
        private readonly CharClassRepository _charClassRepository;
        public CharClassService(CharClassRepository charClassRepository)
        {
            _charClassRepository = charClassRepository;
        }


        public List<CharClass> getAll()
        {
            // TO DO VERIFICATION
            return _charClassRepository.GetAll().ToList();
        }

        public void Add(CharClass charClass)
        {
            // TO DO VERIFICATION
            _charClassRepository.Add(charClass);
        }

        public CharClass GetOne(int id)
        {
            CharClass? charClass = _charClassRepository.GetOne(id);

            if(charClass == null)
            {
                throw new CharClassNotFoundException(id);
            }

            return charClass;
        }

        public List<CharClass> GetSomeByName(string filter)
        {
            return _charClassRepository.GetSomeByName(filter);
        }
    }
}
