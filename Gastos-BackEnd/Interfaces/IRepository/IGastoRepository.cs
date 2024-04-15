using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IRepository
{
    public interface IGastoRepository
    {
        List<Gasto> GetByPersonaId(Guid personald);
        bool SaveGasto(Gasto gastoRequest);
    }
}
