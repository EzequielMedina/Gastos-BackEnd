using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Interfaces.IServices
{
    public interface ICategoriaService
    {
        ResponseBase GetAllCategoria();
        Categorium GetByIdCategoria(string categoriaId);
    }
}
