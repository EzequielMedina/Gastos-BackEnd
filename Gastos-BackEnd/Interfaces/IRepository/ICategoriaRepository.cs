using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IRepository
{
    public interface ICategoriaRepository
    {
        List<Categorium> GetAllCategoria();
    }
}
