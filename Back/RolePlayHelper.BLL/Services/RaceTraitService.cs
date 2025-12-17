using RolePlayHelper.BLL.Exceptions.RaceTrait;
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.BLL.Services
{
    public class RaceTraitService
    {
        private readonly RaceTraitRepository _raceTraitRepository;
        public RaceTraitService(RaceTraitRepository raceTraitRepository)
        {
            _raceTraitRepository = raceTraitRepository;
        }
        
        public List<RaceTrait> GetAll()
        {
           return _raceTraitRepository.GetAll().ToList();
        }

        public void Add(RaceTrait raceTrait)
        {
            if(_raceTraitRepository.GetByName(raceTrait.Name) != null)
            {
                throw new RaceTraitAlreadyExistsException($"Race trait with name {raceTrait.Name} already exists");
            }

            _raceTraitRepository.Add(raceTrait);
        }

        public IEnumerable<RaceTrait> GetSomeByName(string filter)
        {
            return _raceTraitRepository.GetSomeByName(filter);
        }
    }
}
