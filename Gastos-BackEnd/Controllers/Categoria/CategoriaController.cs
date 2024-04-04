using Gastos_BackEnd.Controllers.User;
using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Gastos_BackEnd.Controllers.Categoria
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ILogger<CategoriaController> _logger;
        private ICategoriaService _categoriaService;
        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService)
        {
            _logger = logger;
            _categoriaService = categoriaService;

        }

        [HttpGet]
        [Route("GetAllCategoria")]
        public IActionResult GetAllCategoria()
        {
            try
            {
                ResponseBase categorias = _categoriaService.GetAllCategoria();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener categorias", ex.Message);
                return BadRequest();
            }
        }
    }
}
