
using RolePlayHelper.BLL.Exceptions.Race;
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
            if(_raceRepository.ExistByName(race.Name))
            {
                throw new RaceAlreadyExistsException($"Race with name {race.Name} already exists");
            }
            _raceRepository.Add(race);
        }
    }
}
