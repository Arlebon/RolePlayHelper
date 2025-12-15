
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
        private readonly StatModifierService _statModifierService;
        public RaceService(RaceRepository raceRepository, LanguageRepository languageRepository, RaceTraitRepository raceTraitRepository, StatModifierService statModifierService)
        {
            _raceRepository = raceRepository;
            _languageRepository = languageRepository;
            _raceTraitRepository = raceTraitRepository;
            _statModifierService = statModifierService;
        }

        public List<Race> GetAll()
        {
            return _raceRepository.GetAll().ToList();
        }

        public List<Race> GetAllWithStatModifier()
        {
            return _raceRepository.GetAllWithStatModifier().ToList();
        }

        public Race GetOneById(int id)
        {
            Race? race = _raceRepository.GetOne(id);

            if(race == null)
            {
                throw new RaceNotFoundException($"The race with ID {id} doesn't exists");
            }

            return race;
        }

        public void Add(Race race) 
        {
            if(_raceRepository.ExistByName(race.Name))
            {
                throw new RaceAlreadyExistsException($"Race with name {race.Name} already exists");
            }

            //race.StatModifier = _statModifierService.GetOne(race.StatModifierId);

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
                    trait.Races.Add(race);
                }
                else
                {
                    verifiedTraits.Add(t);
                    t.Races.Add(race);
                }

            });

            race.Traits = verifiedTraits;

            _raceRepository.Add(race);
        }

        public void Delete(Race race)
        {
            if (_raceRepository.GetOne(race.Id) == null)
            {
                throw new RaceNotFoundException($"Race with ID {race.Id} doesn't exist");
            }
            
            _raceRepository.Delete(race);
        }

        public void Update(int id, Race race)
        {
            Race? existing = _raceRepository.GetOne(id);

            if (existing == null)
            {
                throw new RaceNotFoundException($"Race with ID {id} doesn't exist");
            }

            existing.Name = race.Name;
            existing.Description = race.Description;
            existing.StatModifierId = race.StatModifierId;
            existing.StatModifier = race.StatModifier;

            List<Language> raceLanguages = new List<Language>();

            raceLanguages = race.Languages.Select(l => _languageRepository.GetByName(l.Name) ?? l).ToList();

            existing.Languages.RemoveAll(l => !raceLanguages.Any(rl => rl.Id == l.Id));

            raceLanguages.ForEach(l =>
            {
                if (!existing.Languages.Any(el => el.Id == l.Id))
                {
                    existing.Languages.Add(l);
                }
            });

            List<RaceTrait> raceTraits = new List<RaceTrait>();

            raceTraits = race.Traits.Select(t => _raceTraitRepository.GetByName(t.Name) ?? t).ToList();

            existing.Traits.RemoveAll(t => !raceTraits.Any(rt => rt.Id == t.Id));

            raceTraits.ForEach(t =>
            {
                if (!existing.Traits.Any(et => et.Id == t.Id))
                {
                    existing.Traits.Add(t);
                }
            });

            _raceRepository.Update(existing);
        }
    }
}
