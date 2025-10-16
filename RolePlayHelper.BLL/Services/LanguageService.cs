using RolePlayHelper.BLL.Exceptions.Language;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.BLL.Services
{
    public class LanguageService
    {
        private readonly LanguageRepository _languageRepository;
        public LanguageService(LanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public List<Language> GetAll()
        {
            return _languageRepository.GetAll().ToList();
        }

        public void Add(Language language)
        {
            if(_languageRepository.GetByName(language.Name) != null)
            {
                throw new LanguageAlreadyExistsException($"Language with name {language.Name} already exists");
            }
            _languageRepository.Add(language);
        }
    }
}
