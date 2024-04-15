using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Gastos_BackEnd.Repository.Entity;

public partial class TarjetaPorPeriodo
{
    [Key]
    public Guid TarjetaPorPeriodoId { get; set; }
    public Guid TarjetaId { get; set; }

    public Guid Periodold { get; set; }

    public int? CoutasTotales { get; set; }

    public int? CoutaActual { get; set; }

    public Guid GastoId { get; set; }

    public virtual Gasto Gasto { get; set; } = null!;
    [JsonIgnore]

    public virtual Periodo PeriodoldNavigation { get; set; } = null!;
    [JsonIgnore]

    public virtual Tarjetum Tarjeta { get; set; } = null!;
}
