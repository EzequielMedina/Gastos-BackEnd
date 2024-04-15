using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Service
{
    public class IngresoService : IIngresoService
    {
        private readonly ILogger<IngresoService> _logger;
        private  IIngresoRepository _ingresoRepository;
        private IUserService _userService;

        public IngresoService(ILogger<IngresoService> logger, IIngresoRepository ingresoRepository, IUserService userService)
        {
            _logger = logger;
            _ingresoRepository = ingresoRepository;
            _userService = userService;
        }

        public ResponseBase GetByIngresoPersonaId(string email)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                Persona? persona = _userService.GetByEmailPersona(email);
                if (persona == null)
                {
                    response.SetError("No se encontro la persona");
                    response.StatusCode = 401;
                    return response;
                }
                Ingreso ingresos = _ingresoRepository.GetByIngresoPersonaId(persona.Personald);
                response.Data = ingresos;
                response.Ok = true;
                response.StatusCode = 200;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el ingreso por persona service catch", ex.Message);
                response.SetError("Error al obtener el ingreso por persona");
                response.StatusCode = 401;
                return response;
            }


        }

        public ResponseBase SaveIngreso(IngresoRequest ingreso)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                Persona? persona = _userService.GetByEmailPersona(ingreso.Email);
                if (persona == null)
                {
                    response.SetError( "No se encontro la persona");
                    response.StatusCode = 401;
                    return response;
                }
                Ingreso ingresoEntity = new Ingreso
                {
                    Ingresold = new Guid(),
                    Monto = ingreso.Monto,
                    Fecha = ingreso.Fecha,
                    Descripcion = ingreso.Descripcion,                  
                };
               bool saveIngreso =  _ingresoRepository.SaveIngreso(ingresoEntity);

                if (!saveIngreso) { 
                    response.SetError("Error al guardar el ingreso");
                    response.StatusCode = 401;
                    return response;
                
                }

                IngresoPorPersona ingresoPorPersona = new IngresoPorPersona
                {
                    Ingresold = ingresoEntity.Ingresold,
                    Personald = persona.Personald
                };

                bool saveIngresoPorPersona = _ingresoRepository.SaveIngresoPorPersona(ingresoPorPersona);

                if (!saveIngresoPorPersona)
                {
                    response.SetError("Error al guardar el ingreso por persona");
                    response.StatusCode = 401;
                    return response;
                }

                response.Ok = true;
                response.StatusCode = 200;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar el ingreso service catch", ex.Message);
                response.SetError("Error al guardar el ingreso");
                response.StatusCode = 401;
                return response;
            }
        }
    }
}
