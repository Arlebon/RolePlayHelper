using Microsoft.AspNetCore.Mvc;
using RolePlayHelper.API.Mappers;
using RolePlayHelper.API.Models.RaceTrait;
using RolePlayHelper.BLL.Services;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceTraitController : ControllerBase
    {
        private readonly RaceTraitService _raceTraitService;
        public RaceTraitController(RaceTraitService raceTraitService)
        {
            _raceTraitService = raceTraitService;
        }

        [HttpGet]
        public ActionResult<List<RaceTrait>> GetAll()
        {
            List<RaceTrait> raceTraits = _raceTraitService.GetAll();
            return Ok(raceTraits);
        }

        [HttpPost]
        public ActionResult Add([FromBody] RaceTraitFormDto form)
        {
            _raceTraitService.Add(form.ToRaceTrait());
            return Created();
        } 
    }
}
