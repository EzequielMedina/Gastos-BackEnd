using Gastos_BackEnd.Controllers.User;
using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Service
{
    public class CategoriaService : ICategoriaService
    {
        private  ICategoriaRepository _categoriaRepository;
        private readonly ILogger<CategoriaService> _logger;

        public CategoriaService(ICategoriaRepository categoriaRepository, ILogger<CategoriaService> logger)
        {
            _categoriaRepository = categoriaRepository;
            _logger = logger;
        }


        public ResponseBase GetAllCategoria()
        {
            ResponseBase response = new ResponseBase();
            try
            {
                List<Categorium> categorias = _categoriaRepository.GetAllCategoria();
                response.Data = categorias;
                response.StatusCode = 200;
                response.Ok = true; 


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener categorias", ex.Message);
                response.StatusCode = 401;
                response.SetError("Error al obtener categorias");
            }
            return response;
        }

        public Categorium GetByIdCategoria( string categoriaId)
        {
            Categorium? categorium = new Categorium();
            try
            {
                categorium = _categoriaRepository.GetByIdCategoria(categoriaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener categorias", ex.Message);
            }

            return categorium;
        }
    }
}
