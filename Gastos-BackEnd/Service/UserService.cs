using Azure.Core;
using Gastos_BackEnd.Helpers;
using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;
using Microsoft.Extensions.Options;

namespace Gastos_BackEnd.Service
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private IUserRepository _userRepository;
        private AppSettings _appSettings;
        private IPeriodoService _periodoService;
        private ITarjetaService _tarjetaService;

        public UserService( IUserRepository userRepository, 
            IOptions<AppSettings> appSettings, 
            ILogger<UserService> logger,
            IPeriodoService periodoService,
            ITarjetaService tarjetaService
            )
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
            _logger = logger;
            _periodoService = periodoService;
            _tarjetaService = tarjetaService;
        }

        public   Persona? GetByEmailPersona(string email)
        {
            Persona? persona = new Persona();
            try
            {
                persona = _userRepository.GetUserByEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener persona por email", ex.Message);
            }
            return persona;
        }

        public ResponseBase GetByPersonasGrupo(GrupoPersonabyToken request)
        {
            ResponseBase responseBase = new ResponseBase();
            List<UserGrupoGastoReponse> listUserGrupoGastoReponse = new ();
            try
            {

                //obtener persona por token
                


                //llamar a la api para que me traiga las personas por grupo

                List<Persona> listPersona = HttpClientHelper.PostListPersonaByOrganizacion(request.Token).Result;
                if (listPersona.Count == 0) { 
                   responseBase.StatusCode = 401;
                   responseBase.SetError("No se encontraron personas");

                    _logger.LogInformation("No se encontraron personas");
                    return responseBase;
                }
                List<Gasto> listGasto = new();
                
                foreach (Persona persona in listPersona)
                {
                    UserGrupoGastoReponse userGrupoGastoReponse = new UserGrupoGastoReponse();
                    userGrupoGastoReponse.Nombre = persona.Nombre;
                    userGrupoGastoReponse.Email = persona.Email;

                    //List<Gasto> listGasto = new();

                    //listGasto = _gastosService.GetByPersonaId(persona.Personald);
                    //if (listGasto.Count == 0) {
                    //    userGrupoGastoReponse.ListGasto = listGasto;
                    //    continue;
                    //}

                    List<PeriodoPorGasto> listPeriodosPorGasto = _periodoService.GetByPeriodoIdPorGasto(request.PeriodoId);
                    List<Gasto> gastosFiltrados  = listPeriodosPorGasto.Where(x => x.Gasto.Personald.ToString() == persona.Personald.ToString()).Select(x => x.Gasto).ToList();

                    List<TarjetaPorPeriodo> listTarjetaPorPeriodo = _tarjetaService.GetByPeriodoIdAndPersonaId(request.PeriodoId, persona.Personald);

                    List<Gasto> gastosPorTarjetas = listTarjetaPorPeriodo.Where(x => x.Gasto.Personald.ToString() == persona.Personald.ToString()).Select(x => x.Gasto).ToList();

                    //Gastos de tarjetas por periodos
                    gastosFiltrados.AddRange(gastosPorTarjetas);
                    userGrupoGastoReponse.ListGasto = gastosFiltrados;
                    listUserGrupoGastoReponse.Add(userGrupoGastoReponse);

                }

                responseBase.StatusCode = 200;
                responseBase.Ok = true;
                responseBase.Data = listUserGrupoGastoReponse;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener personas por grupo UserService", ex.Message);
                responseBase.StatusCode = 400;
                responseBase.SetError("Error al obtener personas por grupo");
            }

            return responseBase;
        }

        public ResponseBase NewUser(UserRequest request)
        {
            ResponseBase responseBase = new ResponseBase();
            UserResponseAuth userResponseAuth = new UserResponseAuth();
            try
            {
                //validamos que el mail del usuario no exista
                var user = GetByEmailPersona(request.Email);
                if (user != null)
                {
                    _logger.LogInformation("El usuario ya existe");
                    responseBase.StatusCode = 202;
                    responseBase.SetError("El usuario ya existe");
                }
                else
                {
                    //creamos el usuario
                    Persona persona = new Persona
                    {
                        Personald = Guid.NewGuid(),
                        Nombre = request.Nombre,
                        Email = request.Email,
                        Contrasena = Encrypt.HashPassword(request.Contrasena)
                    };
                    Guid personaId = _userRepository.NewUser(persona);
                    //generamos el token
                    string token = Encrypt.GenerateToken(persona, _appSettings.SecretToken);
                    
                    userResponseAuth.Nombre = persona.Nombre;
                    userResponseAuth.Email = persona.Email;
                    userResponseAuth.Token = token;

                    responseBase.StatusCode = 200;
                    responseBase.Ok = true;
                    responseBase.Data = userResponseAuth;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario, " + ex.Message);
                responseBase.StatusCode = 400;
                responseBase.SetError("Error al crear usuario");
            }
            return responseBase;
        }

        public ResponseBase UserAuth(AuthRequest req)
        {
            string token = string.Empty;
            ResponseBase responseBase = new ResponseBase();
            UserResponseAuth userResponseAuth = new UserResponseAuth();
            try
            {
                var user = _userRepository.GetUserByEmail(req.Email);

                if (user != null)
                {
                    bool isValidadPassword = Encrypt.ComparePassword(req.Contrasena, user.Contrasena);
                    if (isValidadPassword)
                    {
                        token = Encrypt.GenerateToken(user, _appSettings.SecretToken);

                        userResponseAuth.Nombre = user.Nombre;
                        userResponseAuth.Email = user.Email;
                        userResponseAuth.Token = token;

                        responseBase.StatusCode = 200;
                        responseBase.Ok = true;
                        responseBase.Data = userResponseAuth;
                        return responseBase;
                    }
                    else
                    {
                        responseBase.StatusCode = 202;
                        responseBase.SetError("Usurio o Contraseña Incorrectos");
                        _logger.LogError("Contraseña incorrecta");
                    }
                }
                else {
                    responseBase.StatusCode = 500;
                    responseBase.SetError("Usurio o Contraseña Incorrectos");
                    _logger.LogError("Usuario no encontrado");
                }
            }
            catch (Exception)
            {
                responseBase.StatusCode = 400;
                responseBase.SetError("Error al autenticar usuario");
            }   
            return responseBase;
        }
    }
}
