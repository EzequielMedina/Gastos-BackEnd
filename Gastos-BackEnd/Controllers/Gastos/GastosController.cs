using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Gastos_BackEnd.Controllers.Gastos
{
    [Route("[controller]")]
    [ApiController]
    public class GastosController : Controller
    {
        private readonly ILogger<GastosController> _logger;
        private readonly IGastosService _gastosService;

        public GastosController(ILogger<GastosController> logger, IGastosService gastosService)
        {
            _logger = logger;
            _gastosService = gastosService;
        }

        [HttpPost]
        [Route("SaveGasto")]
        public IActionResult SaveGastos([FromBody] GastoRequest gastoRequest)
        {
            try
            {
                ResponseBase response = _gastosService.SaveGasto(gastoRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar gasto ", ex.Message);
                return BadRequest();
            }
        }
    }
}
