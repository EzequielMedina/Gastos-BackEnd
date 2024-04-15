using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IRepository
{
    public interface IUserRepository
    {
        public Guid NewUser(Persona request);
        public Persona? GetUserByEmail(string email);
        List<Persona> GetByPersonasGrupo();
    }
}
