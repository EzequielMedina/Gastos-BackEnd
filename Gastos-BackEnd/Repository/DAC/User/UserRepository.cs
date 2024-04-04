using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Repository.Entity;
using System.Text;

namespace Gastos_BackEnd.Repository.DAC.User
{
    public class UserRepository : IUserRepository
    {
        private ILogger<UserRepository> _logger;
        private  GastosDbContext _context;

        public UserRepository(GastosDbContext gastosDbContext)
        {
            _context = gastosDbContext;
        }
        public Persona? GetUserByEmail(string email)
        {
            Persona persona = null;
            try
            {
                persona = _context.Personas.FirstOrDefault(x => x.Email == email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuario por email, " + ex.Message);
                return persona;
            }
            return persona;
        }

        public Guid NewUser(Persona persona)
        {



            try
            {
                _context.Personas.Add(persona);
                _context.SaveChanges();

                // Una vez que se guarda en la base de datos, puedes acceder al ID generado automáticamente
                Guid personaId = persona.Personald;
                // Ahora puedes hacer lo que necesites con el ID, como devolverlo en algún lugar
                return personaId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario, " + ex.Message);
                throw;
            }
        }
    }
}
