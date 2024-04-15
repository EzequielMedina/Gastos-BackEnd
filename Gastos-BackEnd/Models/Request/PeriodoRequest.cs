namespace Gastos_BackEnd.Models.Request
{
    public class PeriodoRequest
    {
        public string? NombrePeriodo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
