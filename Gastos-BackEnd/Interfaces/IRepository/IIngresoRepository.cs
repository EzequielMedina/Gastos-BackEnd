using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IRepository
{
    public interface IIngresoRepository
    {
        Ingreso GetByIngresoPersonaId(Guid personald);
        bool SaveIngreso(Ingreso ingresoEntity);
        bool SaveIngresoPorPersona(IngresoPorPersona ingresoPorPersona);
    }
}
