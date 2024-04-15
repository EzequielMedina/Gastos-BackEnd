namespace Gastos_BackEnd.Models.Request
{
    public class GastoRequest
    {
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string CategoriaId { get; set; }
        public string TipoGastoId { get; set; }
        public string NombreGasto { get; set; }
        public bool esTarjeta { get; set; }
        public string Email { get; set; }
        public string PeriodoId { get; set; }
        public string TarjetaId { get; set; }
        public int CoutasTotales { get; set; }
        public int CoutaActual { get; set; }

    }
}
