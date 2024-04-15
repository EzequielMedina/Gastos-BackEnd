using Gastos_BackEnd.Entity;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IRepository
{
    public interface ITarjetaRepository
    {
        List<Tarjetum> GetAllTarjetaByPersonaId(Guid personald);
        Tarjetum? GetById(string tarjetaId, string personaId);
        Tarjetum? GetByNombre(string nombre);
        List<TarjetaPorPeriodo> GetByPeriodoIdAndTarjetaId(string periodoId, Guid tarjetaId);
        PersonaPorTarjetum? GetByPersonaIdAndTarjetaId(Guid personald, Guid tarjetaId);
        bool SavePersonaPorTarjeta(PersonaPorTarjetum personaPorTarjetum);
        bool SaveTarjeta(Tarjetum tarjeta);
        bool SaveTarjetaPorPeriodo(TarjetaPorPeriodo tarjetaPorPeriodo);
    }
}
