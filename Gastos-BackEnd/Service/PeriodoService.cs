using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Service
{
    public class PeriodoService : IPeriodoService
    {
        private  IPeriodoRepository _periodoRepository;
        private readonly ILogger<PeriodoService> _logger;

        public PeriodoService(ILogger<PeriodoService> logger, IPeriodoRepository periodoRepository)
        {
            _logger = logger;
            _periodoRepository = periodoRepository;
        }

        public ResponseBase GetByPeriodoSinVencer()
        {
            ResponseBase responseBase = new ResponseBase();
            try
            {
                List<Periodo> listPeriodo = _periodoRepository.GetAllPeriodo();
                if (listPeriodo.Count <= 0) { 
                    responseBase.StatusCode = 401;
                    responseBase.SetError("No hay periodos");
                    return responseBase;
                }

                List<Periodo> listPeriodoSinVencer = listPeriodo.Where(x => x.FechaFin > DateTime.Now).ToList();

                if (listPeriodoSinVencer.Count <= 0)
                {
                    responseBase.StatusCode = 401;
                    responseBase.SetError("No hay periodos sin vencer");
                    return responseBase;
                }

                responseBase.StatusCode = 200;
                responseBase.Ok = true;
                responseBase.Data = listPeriodoSinVencer;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al obtener periodo sin vencer", ex.Message);
                responseBase.StatusCode = 401;
                responseBase.SetError("Error al obtener periodo sin vencer");
            }
            return  responseBase;
        }

        public ResponseBase SavePeriodo(PeriodoRequest periodoRequest)
        {
            ResponseBase responseBase = new ResponseBase();
            try
            {
                Periodo periodo = new Periodo
                {
                    Periodold = Guid.NewGuid(),
                    FechaInicio = periodoRequest.FechaInicio,
                    FechaFin = periodoRequest.FechaFin,
                    NombrePeriodo = periodoRequest.NombrePeriodo,
                    Monto = 0,
                };

                bool save = _periodoRepository.SavePeriodo(periodo);
                if (save)
                {
                    responseBase.StatusCode = 200;
                    responseBase.Ok = true;
                    responseBase.Data = periodo;
                }
                else { 
                    responseBase.StatusCode = 401;
                    responseBase.SetError("Error al guardar periodo");
                }


            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al guardar periodo", ex.Message);
                responseBase.StatusCode = 401;
                responseBase.SetError("Error al guardar periodo");
            }
            return responseBase;
        }

        public bool SavePeriodoXGasto(string periodoId, Gasto gasto)
        {
            bool save = false;
            try
            {

                Periodo? periodo = _periodoRepository.GetByIdPeriodo(periodoId);

                if (periodo == null)
                {
                    _logger.LogError("Error al obtener periodo por id", "No se encontro el periodo");
                    return save;
                }

                PeriodoPorGasto periodoPorGasto = new PeriodoPorGasto
                {
                    Periodold = periodo.Periodold,
                    GastoId = gasto.GastoId,
                    Gasto = gasto,
                    PeriodoldNavigation = periodo
                };
                save = _periodoRepository.SavePeriodoXGasto(periodoPorGasto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar periodo por gasto", ex.Message);

            }
            return save;

        }

        public List<PeriodoPorGasto> GetByPeriodoIdPorGasto(string periodoId)
        {
            List<PeriodoPorGasto> periodoPorGastos = new List<PeriodoPorGasto>();
            try
            {
                periodoPorGastos = _periodoRepository.GetByPeriodoIdPorGasto(periodoId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener periodo por gasto", ex.Message);
            }
            return periodoPorGastos;
        }

        public Periodo GetByIdPeriodo(string periodoId)
        {

            Periodo periodo = null;

            try
            {
                periodo = _periodoRepository.GetByIdPeriodo(periodoId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener periodo por id", ex.Message);
            }
            return periodo;
        }
    }
}
