using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IServices
{
    public interface IGastosService
    {
        List<Gasto> GetByPersonaId(Guid personald);
        ResponseBase SaveGasto(GastoRequest gastoRequest);

    }
}
