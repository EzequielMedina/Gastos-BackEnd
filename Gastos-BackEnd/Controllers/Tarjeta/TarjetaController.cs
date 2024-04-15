using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Gastos_BackEnd.Controllers.Tarjeta
{
    [ApiController]
    [Route("[controller]")]
    public class TarjetaController : Controller
    {
        private readonly ILogger<TarjetaController> _logger;
        private ITarjetaService _tarjetaService;

        public TarjetaController(ILogger<TarjetaController> logger, ITarjetaService tarjetaService)
        {
            _logger = logger;
            _tarjetaService = tarjetaService;
        }

        [HttpPost]
        [Route("SaveTarjeta")]
        public IActionResult SaveTarjeta([FromBody] TarjetaRequest tarjetaRequest)
        {
            try
            {
                ResponseBase response = _tarjetaService.SaveTarjeta(tarjetaRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar la tarjeta controller", ex.Message);
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("GetAllTarjetaByEmail")]
        public IActionResult GetAllTarjetaByEmail([FromBody] string email)
        {
            try
            {
                ResponseBase response = _tarjetaService.GetAllTarjetaByEmail(email);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al traer las tarjetas por email la tarjeta controller", ex.Message);
                return BadRequest();
            }
        }
    }
}
