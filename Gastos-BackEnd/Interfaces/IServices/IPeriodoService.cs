using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IServices
{
    public interface IPeriodoService
    {
        Periodo GetByIdPeriodo(string periodoId);
        List<PeriodoPorGasto> GetByPeriodoIdPorGasto(string periodoId);
        ResponseBase GetByPeriodoSinVencer();
        ResponseBase SavePeriodo(PeriodoRequest periodoRequest);
        bool SavePeriodoXGasto(string periodoId, Gasto gastoId);
    }
}
