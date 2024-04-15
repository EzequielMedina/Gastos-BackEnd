using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IRepository
{
    public interface IPeriodoRepository
    {
        List<Periodo> GetAllPeriodo();
        Periodo? GetByIdPeriodo(string periodoId);
        List<PeriodoPorGasto> GetByPeriodoIdPorGasto(string periodoId);
        bool SavePeriodo(Periodo periodo);
        bool SavePeriodoXGasto(PeriodoPorGasto periodoPorGasto);
    }
}
