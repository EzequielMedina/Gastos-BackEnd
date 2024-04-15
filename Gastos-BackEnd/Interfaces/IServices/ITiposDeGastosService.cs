using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IServices
{
    public interface ITiposDeGastosService
    {
        ResponseBase GetAllTiposDeGastos();
        TipoGasto GetByIdTipoGasto(string tipoGastoId);
    }
}
