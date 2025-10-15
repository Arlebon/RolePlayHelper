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
            _raceTraitRepository.Add(raceTrait);
        }
    }
}
