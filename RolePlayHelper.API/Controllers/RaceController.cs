using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RolePlayHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() {

            
    }
}
