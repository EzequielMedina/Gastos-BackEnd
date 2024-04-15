using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Gastos_BackEnd.Controllers.Periodo
{
    [ApiController]
    [Route("[controller]")]
    public class PeriodoController : Controller
    {

        private readonly ILogger<PeriodoController> _logger;
        private IPeriodoService _periodoService;

        public PeriodoController(ILogger<PeriodoController> logger, IPeriodoService periodoService)
        {
            _logger = logger;
            _periodoService = periodoService;
        }

        [HttpPost]
        [Route("SavePeriodo")]
        public IActionResult SavePeriodo([FromBody] PeriodoRequest periodoRequest )
        {
            try
            {
                ResponseBase responseBase = _periodoService.SavePeriodo(periodoRequest);
                return Ok(responseBase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar periodo", ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetByPeriodoSinVencer")]
        public IActionResult GetByPeriodoSinVencer()
        {
            try
            {
                ResponseBase responseBase = _periodoService.GetByPeriodoSinVencer();
                return Ok(responseBase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener periodo sin vencer", ex.Message);
                return BadRequest();
            }
        }
    }
}
