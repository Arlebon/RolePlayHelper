using Microsoft.AspNetCore.Mvc;
using RolePlayHelper.API.Models;
using RolePlayHelper.BLL.Services; 
using RolePlayHelper.API.Mappers;
using RolePlayHelper.DL.Entities;
using RolePlayHelper.API.Services;

namespace RolePlayHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public ActionResult Register([FromBody] UserRegisterFormDto form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _userService.CreateUser(form.ToUser());
            return Created("User created");
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserLoginFormDto form)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // on recupere l'utilisateur
            User user  = _userService.Login(form.Login, form.Password);

            string token = _authService.GenerateToken(user);

            return Ok("User logged in");
        }

    }
}
