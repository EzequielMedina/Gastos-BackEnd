using System;
using System.Collections.Generic;

namespace Gastos_BackEnd.Repository.Entity;

public partial class PeriodoPorGasto
{
    public Guid Periodold { get; set; }

    public Guid GastoId { get; set; }

    public virtual Gasto Gasto { get; set; } = null!;

    public virtual Periodo PeriodoldNavigation { get; set; } = null!;
}
