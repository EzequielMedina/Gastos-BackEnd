using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gastos_BackEnd.Repository.Entity;

public partial class Periodo
{
    public Guid Periodold { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }


    public decimal? Monto { get; set; }
    public string? NombrePeriodo { get; set; }


}
