using Gastos_BackEnd.Models.Request;
using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IServices
{
    public interface ITarjetaService
    {
        ResponseBase GetAllTarjetaByEmail(string email);
        Tarjetum GetById(string tarjetaId, string personaId);
        List<TarjetaPorPeriodo> GetByPeriodoIdAndPersonaId(string periodoId, Guid personald);
        ResponseBase SaveTarjeta(TarjetaRequest tarjetaRequest);
        bool SaveTarjetaPorPeriodo(Tarjetum tarjeta, Periodo periodo, Gasto gasto, GastoRequest gastoRequest);
    }
}
