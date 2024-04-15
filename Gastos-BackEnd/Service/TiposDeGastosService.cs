using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Service
{
    public class TiposDeGastosService : ITiposDeGastosService
    {
        private readonly ILogger<TiposDeGastosService> _logger;
        private ITiposDeGastosRepository _tiposDeGastosRepository;

        public TiposDeGastosService(ITiposDeGastosRepository tiposDeGastosRepository, ILogger<TiposDeGastosService> logger)
        {
            _tiposDeGastosRepository = tiposDeGastosRepository;
            _logger = logger;
        }

        public ResponseBase GetAllTiposDeGastos()
        {
            ResponseBase response = new ResponseBase();
            try
            {
                List<TipoGasto> tipoGastos = _tiposDeGastosRepository.GetTiposDeGastos();
                response.Data = tipoGastos;
                response.StatusCode = 200;
                response.Ok = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener tipos de gastos", ex.Message);
                response.StatusCode = 401;
                response.SetError("Error al obtener tipos de gastos");
                
            }
            return response;
        }

        public TipoGasto GetByIdTipoGasto(string tipoGastoId)
        {
            TipoGasto? tipoGasto = new TipoGasto();
            try
            {
                tipoGasto = _tiposDeGastosRepository.GetByIdTipoGasto(tipoGastoId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener tipos de gastos", ex.Message);
            }
            return tipoGasto;
        }
    }
}
