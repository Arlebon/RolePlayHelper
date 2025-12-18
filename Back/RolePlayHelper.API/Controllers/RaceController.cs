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
        private readonly RaceTraitService _raceTraitService;
        private readonly LanguageService _languageService;

        public RaceController(RaceService raceService, RaceTraitService raceTraitService, LanguageService languageService)
        {
            _raceService = raceService;
            _raceTraitService = raceTraitService;
            _languageService = languageService;
        }

        [HttpGet("RaceListAddChar")]
        public ActionResult<List<RaceListAddCharDto>> GetAllAddChar()
        {
            List<RaceListAddCharDto> races = _raceService.GetAll().Select(r => r.ToRaceListAddCharDto()).ToList();
            return Ok(races);
        }

        [HttpGet]
        public ActionResult<List<RaceListDto>> GetAllWithStatModifier()
        {
            List<RaceListDto> races = _raceService.GetAllWithStatModifier().Select(r => r.ToRaceListDto()).ToList();
            return Ok(races);
        }

        [HttpGet("{id}")]
        public ActionResult GetOneById([FromRoute] int id)
        {
            RaceListAddCharDto race = _raceService.GetOneById(id).ToRaceListAddCharDto();
            return Ok(race);
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public ActionResult Add([FromBody] RaceFormDto form)
        {
            List<RaceTrait> raceTraits = form.Traits
                                .Select(traitId => _raceTraitService.GetById(traitId))
                                .ToList();
            List<Language> languages = form.Languages
                .Select(langId => _languageService.GetById(langId))
                .ToList();

            _raceService.Add(form.ToRace(),form.Languages,form.Traits);
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

        [HttpGet("RaceListAddCharFiltered")]
        public ActionResult GetSomeByName([FromQuery] string filter)
        {
            List<RaceListAddCharDto> races = _raceService.GetSomeByName(filter).Select(r => r.ToRaceListAddCharDto()).ToList();
            return Ok(races);
        }
    }
}
