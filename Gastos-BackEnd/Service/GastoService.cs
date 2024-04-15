using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Service
{
    public class GastoService : IGastosService
    {

        private  IGastoRepository _gastoRepository;
        private ICategoriaService _categoriaService;
        private ITiposDeGastosService _tiposDeGastosService;
        private IUserService _userService;
        private IPeriodoService _periodoService;
        private ITarjetaService _tarjetaService;
        private readonly ILogger<GastoService> _logger;

        public GastoService(ILogger<GastoService> logger, 
            IGastoRepository gastoRepository, 
            ICategoriaService categoriaService, 
            ITiposDeGastosService tiposDeGastosService,
            IUserService userService,
            IPeriodoService periodoService,
            ITarjetaService tarjeta)
        {
            _logger = logger;
            _gastoRepository = gastoRepository;
            _categoriaService = categoriaService;
            _tiposDeGastosService = tiposDeGastosService;
            _userService = userService;
            _periodoService = periodoService;
            _tarjetaService = tarjeta;
        }
        public ResponseBase SaveGasto(GastoRequest gastoRequest)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                //validamos que la categoria exista
                response.StatusCode = 401;

                Categorium categoria = _categoriaService.GetByIdCategoria(gastoRequest.CategoriaId);
                if (categoria == null)
                {
                    response.SetError("La categoria no existe");
                    return response;
                }

                //validamos que el tipo de gasto exista
                TipoGasto tipoGasto = _tiposDeGastosService.GetByIdTipoGasto(gastoRequest.TipoGastoId);

                if (tipoGasto == null)
                {
                    response.SetError("El tipo de gasto no existe");
                    return response;
                }

                //validamos que la tarjeta Exista en caso que de que el gasto sea con tarjeta

                //validamos que el usuario exista

                Persona? persona = _userService.GetByEmailPersona(gastoRequest.Email);

                if (persona == null) { 
                    response.SetError("El usuario no existe");
                    return response;
                }

                //validamos que el monto sea mayor a 0

                if (gastoRequest.Monto <= 0)
                {
                    response.SetError("El monto debe ser mayor a 0");
                    return response;
                }

                //validamos que la descripcion no sea nula

                if (gastoRequest.Descripcion == null)
                {
                    gastoRequest.Descripcion = string.Empty;
                }



                //guardamos el gasto
                Gasto gasto = new Gasto
                {
                    GastoId = Guid.NewGuid(),
                    Descripcion = gastoRequest.Descripcion,
                    Monto = gastoRequest.Monto,
                    Fecha = gastoRequest.Fecha,
                    Categoriald = Guid.Parse(gastoRequest.CategoriaId),
                    TipoGastold = Guid.Parse(gastoRequest.TipoGastoId),
                    NombreGasto = gastoRequest.NombreGasto,
                    Personald = persona.Personald
                };

                bool save = _gastoRepository.SaveGasto(gasto);

                if (save)
                {
                    bool saveTarjetaOGastoPorPeriodo = false;
                    if (gastoRequest.esTarjeta)
                    {

                        //creamos tarjeta por periodo
                        Tarjetum tarjeta = _tarjetaService.GetById(gastoRequest.TarjetaId, persona.Personald.ToString());
                        if (tarjeta == null)
                        {
                            response.SetError("se guardo el gasto pero no se pudo guardar la relacion porque no exite la tarjeta en su tarjetero");
                            response.StatusCode = 401;
                            return response;
                        }

                        Periodo periodo = _periodoService.GetByIdPeriodo(gastoRequest.PeriodoId);

                        if (periodo == null)
                        {
                            response.SetError("se guardo el gasto pero no se pudo guardar la relacion porque no exite el periodo");
                            response.StatusCode = 401;
                            return response;
                        }

                        saveTarjetaOGastoPorPeriodo = _tarjetaService.SaveTarjetaPorPeriodo(tarjeta, periodo, gasto, gastoRequest);

                        if (!saveTarjetaOGastoPorPeriodo)
                        {
                            response.SetError("Error al guardar tarjeta por periodo");
                            response.StatusCode = 401;
                            return response;
                        }
                    }
                    else {

                        saveTarjetaOGastoPorPeriodo = _periodoService.SavePeriodoXGasto(gastoRequest.PeriodoId, gasto);
                    }


                    if (saveTarjetaOGastoPorPeriodo) { 
                        response.StatusCode = 200;
                        response.Ok = true;
                        response.Data =  gasto;                   
                    }
                    else
                    {
                        response.SetError("Error al guardar periodo por gasto");
                        return response;
                    }

                }
                else
                {
                    response.SetError("Error al guardar gasto");
                    return response;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar gasto", ex.Message);
                response.StatusCode = 401;
                response.SetError("Error al guardar gasto");
                return response;
                
            }
            return response;
        }

        public List<Gasto> GetByPersonaId(Guid personald)
        {
            List<Gasto> listGasto = new List<Gasto>();
            try
            {
                listGasto = _gastoRepository.GetByPersonaId(personald);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener gastos por persona gastoService ", ex.Message);
            }
            return listGasto;
        }
    }
}
