
using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.BLL.Services
{
    public class RaceService
    {
        private readonly RaceRepository _raceRepository;
        public RaceService(RaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }

        public List<Race> GetAll()
        {
            return _raceRepository.GetAll().ToList();
        }

        public void Add(Race race) 
        { 
            _raceRepository.Add(race);
        }
    }
}
