using Gastos_BackEnd.Repository.Entity;

namespace Gastos_BackEnd.Models.Response
{
    public class UserGrupoGastoReponse
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Grupo { get; set; }

        public List<Gasto> ListGasto { get; set; }

    }
}
