using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;

namespace Gastos_BackEnd.Interfaces.IServices
{
    public interface IIngresoService
    {
        ResponseBase GetByIngresoPersonaId(string email);
        ResponseBase SaveIngreso(IngresoRequest ingreso);
    }
}
