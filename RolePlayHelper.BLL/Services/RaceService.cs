
using RolePlayHelper.BLL.Exceptions.Race;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.BLL.Services
{
    public class RaceService
    {
        private readonly RaceRepository _raceRepository;
        private readonly LanguageRepository _languageRepository;
        private readonly RaceTraitRepository _raceTraitRepository;
        public RaceService(RaceRepository raceRepository, LanguageRepository languageRepository, RaceTraitRepository raceTraitRepository)
        {
            _raceRepository = raceRepository;
            _languageRepository = languageRepository;
            _raceTraitRepository = raceTraitRepository;
        }

        public List<Race> GetAll()
        {
            return _raceRepository.GetAll().ToList();
        }

        public void Add(Race race) 
        {
            if(_raceRepository.ExistByName(race.Name))
            {
                throw new RaceAlreadyExistsException($"Race with name {race.Name} already exists");
            }

            List<Language> verifiedLanguages = new List<Language>();

            race.Languages.ForEach(l =>
            {
                Language? language = _languageRepository.GetByName(l.Name);

                if (language != null)
                {
                    verifiedLanguages.Add(language);
                }
                else
                {
                    verifiedLanguages.Add(l);
                }

            });

            race.Languages = verifiedLanguages;

            List<RaceTrait> verifiedTraits = new List<RaceTrait>();

            race.Traits.ForEach(t =>
            {
                RaceTrait? trait = _raceTraitRepository.GetByName(t.Name);

                if (trait != null)
                {
                    verifiedTraits.Add(trait);
                }
                else
                {
                    verifiedTraits.Add(t);
                }

            });

            race.Traits = verifiedTraits;

            _raceRepository.Add(race);
        }
    }
}
