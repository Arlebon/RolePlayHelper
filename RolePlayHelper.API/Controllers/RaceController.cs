using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolePlayHelper.API.Mappers;
using RolePlayHelper.API.Models;
using RolePlayHelper.BLL.Services;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly RaceService _raceService;

        public RaceController(RaceService raceService)
        {
            _raceService = raceService;
        }

        [HttpGet]
        public ActionResult<List<RaceIndexDto>> GetAll()
        {
            List<RaceIndexDto> races = _raceService.GetAll().Select(r => r.ToRaceIndexDto()).ToList();
            return Ok(races);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] RaceFormDto form)
        {
            _raceService.Add(form.ToRace());
            return Created();
        }
    }
}
