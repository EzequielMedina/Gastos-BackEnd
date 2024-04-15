using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IRepository
{
    public interface ITiposDeGastosRepository
    {
        TipoGasto GetByIdTipoGasto(string tipoGastoId);
        List<TipoGasto> GetTiposDeGastos();
    }
}
