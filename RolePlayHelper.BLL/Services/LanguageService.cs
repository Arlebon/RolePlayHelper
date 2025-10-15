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
            _languageRepository.Add(language);
        }
    }
}
