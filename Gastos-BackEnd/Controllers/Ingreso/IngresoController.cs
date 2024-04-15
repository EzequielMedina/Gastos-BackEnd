using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Gastos_BackEnd.Controllers.Ingreso
{
    [ApiController]
    [Route("[controller]")]
    public class IngresoController : Controller
    {
        private readonly ILogger<IngresoController> _logger;
        private IIngresoService _ingresoService;

        public IngresoController(ILogger<IngresoController> logger, IIngresoService ingresoService)
        {
            _logger = logger;
            _ingresoService = ingresoService;
        }

        [HttpPost]
        [Route("SaveIngreso")]
        public IActionResult SaveIngreso([FromBody] IngresoRequest ingreso)
        {
            try
            {
                ResponseBase response = _ingresoService.SaveIngreso(ingreso);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar el ingreso controller", ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("GetByIngresoPersonaId")]
        public IActionResult GetByIngresoPersonaId([FromBody] string email) {

            try
            {
                ResponseBase responseBase = _ingresoService.GetByIngresoPersonaId(email);

                    return Ok(responseBase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el ingreso por persona controller", ex.Message);
                return BadRequest();
                
            }
            

        }
    }
}
