using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IServices
{
    public interface IUserService
    {
        Persona? GetByEmailPersona(string email);
        ResponseBase GetByPersonasGrupo(string periodoId);
        ResponseBase NewUser(UserRequest request);
        ResponseBase UserAuth(AuthRequest req);
    }
}
