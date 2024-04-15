using Azure;
using Gastos_BackEnd.Entity;
using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Service
{
    public class TarjetaService : ITarjetaService
    {
        private readonly ILogger<TarjetaService> _logger;
        private  ITarjetaRepository _tarjetaRepository;
        private  IUserRepository _userService;

        public TarjetaService(ILogger<TarjetaService> logger, ITarjetaRepository tarjetaRepository, IUserRepository userService)
        {
            _logger = logger;
            _tarjetaRepository = tarjetaRepository;
            _userService = userService;
        }

        public ResponseBase GetAllTarjetaByEmail(string email)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    response.SetError("El email es requerido");
                    response.StatusCode = 401;
                    return response;
                }

                Persona? persona = _userService.GetUserByEmail(email);

                if (persona == null)
                {
                    response.SetError("No se encontro la persona");
                    response.StatusCode = 401;
                    return response;
                }

                List<Tarjetum> listTarjeta = _tarjetaRepository.GetAllTarjetaByPersonaId(persona.Personald);

                if (listTarjeta.Count == 0)
                {
                    response.SetError("No se encontraron tarjetas");
                    response.StatusCode = 401;
                    return response;
                }

                response.Ok = true;
                response.StatusCode = 200;
                response.Data = listTarjeta;
                return response;

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al traer las tarjetas por email service", ex.Message);
                response.SetError("Error al traer las tarjetas por email");
                response.StatusCode = 401;
                return response;
            }
        }

        public Tarjetum GetById(string tarjetaId, string personaId)
        {
            Tarjetum tarjeta = null;
            try
            {
                tarjeta = _tarjetaRepository.GetById(tarjetaId, personaId);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al traer tarjeta por id", ex.Message);
            }
            return tarjeta;
        }

        public List<TarjetaPorPeriodo> GetByPeriodoIdAndPersonaId(string periodoId, Guid personald)
        {
            List<TarjetaPorPeriodo> listTarjetasPorPeriodos = new List<TarjetaPorPeriodo>();
            try
            {
                List<Tarjetum> listTarjeta = _tarjetaRepository.GetAllTarjetaByPersonaId(personald);

                if (listTarjeta.Count == 0) { 
                    return listTarjetasPorPeriodos;
                }

                foreach (Tarjetum tarjeta in listTarjeta)
                {
                    List<TarjetaPorPeriodo> listTarjetaPorPeriodo = _tarjetaRepository.GetByPeriodoIdAndTarjetaId(periodoId, tarjeta.TarjetaId);

                    if (listTarjetaPorPeriodo.Count == 0)
                    {
                        continue;
                    }

                    listTarjetasPorPeriodos.AddRange(listTarjetaPorPeriodo);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al traer tarjetas por periodo y persona", ex.Message);
            }

            return listTarjetasPorPeriodos;
        }

        public ResponseBase SaveTarjeta(TarjetaRequest tarjetaRequest)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                if (string.IsNullOrEmpty(tarjetaRequest.Email)) { 
                    response.SetError("El email es requerido");
                    response.StatusCode = 401;
                    return response;
                }

                if (string.IsNullOrEmpty(tarjetaRequest.Nombre))
                {
                    response.SetError("El nombre es requerido");
                    response.StatusCode = 401;
                    return response;
                }

                Persona? persona = _userService.GetUserByEmail(tarjetaRequest.Email);

                if (persona == null)
                {
                    response.SetError("No se encontro la persona");
                    response.StatusCode = 401;
                    return response;
                }

                Tarjetum tarjeta = null;

                tarjeta = _tarjetaRepository.GetByNombre(tarjetaRequest.Nombre);

                if (tarjeta == null) { 
                    tarjeta = new Tarjetum();
                    tarjeta.TarjetaId = Guid.NewGuid();
                    tarjeta.Nombre = tarjetaRequest.Nombre;
                             
                    bool result = _tarjetaRepository.SaveTarjeta(tarjeta);

                    if (!result)
                    {
                        response.SetError("Error al guardar la tarjeta");
                        response.StatusCode = 401;
                        return response;
                    }
                }
     
                PersonaPorTarjetum personaPorTarjetum = null;

                personaPorTarjetum = _tarjetaRepository.GetByPersonaIdAndTarjetaId(persona.Personald, tarjeta.TarjetaId);

                if (personaPorTarjetum != null) { 
                
                    response.SetError("La persona ya tiene la tarjeta");
                    response.StatusCode = 401;
                    return response;
                
                }
                personaPorTarjetum = new PersonaPorTarjetum();
                personaPorTarjetum.PersonaPorTarjetaId = Guid.NewGuid();
                personaPorTarjetum.PersonaId = persona.Personald;
                personaPorTarjetum.TarjetaId = tarjeta.TarjetaId;
                personaPorTarjetum.Persona = persona;
                personaPorTarjetum.Tarjeta = tarjeta;

                bool resultPersonaPorTarjeta = _tarjetaRepository.SavePersonaPorTarjeta(personaPorTarjetum);

                if (!resultPersonaPorTarjeta)
                {
                    response.SetError("Error al guardar la persona por tarjeta");
                    response.StatusCode = 401;
                    return response;
                }

                response.Ok = true;
                response.StatusCode = 200;
                return response;

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al guardar la tarjeta service", ex.Message);
                response.SetError("Error al guardar la tarjeta");
                response.StatusCode = 401;
                return response;
            }
        }

        public bool SaveTarjetaPorPeriodo(Tarjetum tarjeta, Periodo periodo, Gasto gasto, GastoRequest gastoRequest)
        {
            bool save = false;
            try
            {
                TarjetaPorPeriodo tarjetaPorPeriodo = new TarjetaPorPeriodo();
                tarjetaPorPeriodo.TarjetaPorPeriodoId = Guid.NewGuid();
                tarjetaPorPeriodo.TarjetaId = tarjeta.TarjetaId;
                tarjetaPorPeriodo.Periodold = periodo.Periodold;
                tarjetaPorPeriodo.GastoId = gasto.GastoId;
                tarjetaPorPeriodo.Gasto = gasto;
                tarjetaPorPeriodo.PeriodoldNavigation = periodo;
                tarjetaPorPeriodo.Tarjeta = tarjeta;
                tarjetaPorPeriodo.CoutaActual = gastoRequest.CoutaActual;
                tarjetaPorPeriodo.CoutasTotales = gastoRequest.CoutasTotales;


                save = _tarjetaRepository.SaveTarjetaPorPeriodo(tarjetaPorPeriodo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar tarjeta por periodo", ex.Message);
                
            }
            return save;
        }
    }
}
