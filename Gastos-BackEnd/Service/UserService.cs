using Azure.Core;
using Gastos_BackEnd.Helpers;
using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Interfaces.IServices;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;
using Microsoft.Extensions.Options;
using System.Text;

namespace Gastos_BackEnd.Service
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private IUserRepository _userRepository;
        private AppSettings _appSettings;

        public UserService( IUserRepository userRepository, IOptions<AppSettings> appSettings, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
            _logger = logger;
        }
        public ResponseBase NewUser(UserRequest request)
        {
            ResponseBase responseBase = new ResponseBase();
            UserResponseAuth userResponseAuth = new UserResponseAuth();
            try
            {
                //validamos que el mail del usuario no exista
                var user = _userRepository.GetUserByEmail(request.Email);
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
