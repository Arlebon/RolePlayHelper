using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolePlayHelper.API.Mappers;
using RolePlayHelper.API.Models.Race;
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
        [Authorize(Roles = "Admin")]
        public ActionResult Add([FromBody] RaceFormDto form)
        {
            _raceService.Add(form.ToRace());
            return Created();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            Race race = _raceService.GetOneById(id);
            _raceService.Delete(race);

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update([FromRoute] int id,  [FromBody] RaceFormDto form)
        {
            _raceService.Update(id, form.ToRace());
            return Ok();
        }
    }
}
