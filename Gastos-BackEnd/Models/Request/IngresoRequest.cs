namespace Gastos_BackEnd.Models.Request
{
    public class IngresoRequest
    {
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Email { get; set; }
    }
}
