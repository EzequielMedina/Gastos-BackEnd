using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Gastos_BackEnd.Controllers.TiposDeGastos
{
    [ApiController]
    [Route("[controller]")]
    public class TiposDeGastosController : Controller
    {
        private readonly ILogger<TiposDeGastosController> _logger;
        private ITiposDeGastosService _tiposDeGastosService;
        public TiposDeGastosController(ILogger<TiposDeGastosController> logger, ITiposDeGastosService tiposDeGastosService)
        {
            _logger = logger;
            _tiposDeGastosService = tiposDeGastosService;
        }

        [HttpGet]
        [Route("GetAllTiposDeGastos")]
        public IActionResult GetAllTiposDeGastos()
        {
            try
            {
                ResponseBase tiposDeGastos = _tiposDeGastosService.GetAllTiposDeGastos();
                return Ok(tiposDeGastos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }        
        }
    }
}
