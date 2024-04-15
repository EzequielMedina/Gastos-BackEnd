using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Gastos_BackEnd.Repository.Entity;

public partial class PeriodoPorGasto
{
    [Key]
    public Guid Periodold { get; set; }
    [Key]
    public Guid GastoId { get; set; }


    public virtual Gasto Gasto { get; set; } = null!;

    [JsonIgnore]

    public virtual Periodo PeriodoldNavigation { get; set; } = null!;
}
