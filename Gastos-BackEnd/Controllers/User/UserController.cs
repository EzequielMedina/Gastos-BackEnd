using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gastos_BackEnd.Controllers.User
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _usersService;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _usersService = userService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] UserRequest request)
        {
            try
            {
                ResponseBase userResult = _usersService.NewUser(request);
                return Ok(userResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario, " + ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Authenticate([FromBody] AuthRequest req)
        {
            try
            {
                ResponseBase auth = _usersService.UserAuth(req);
                return Ok(auth);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al autenticar usuario, " + ex.Message);
                return BadRequest(ex.Message);
            }

        }
        [Authorize]
        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser([FromQuery] string email)
        {
            try
            {
                ResponseBase user = null;
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuario, " + ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
