using System;
using System.Collections.Generic;

namespace Gastos_BackEnd.Repository.Entity;

public partial class TarjetaPorPeriodo
{
    public Guid TarjetaId { get; set; }

    public Guid Periodold { get; set; }

    public virtual Periodo PeriodoldNavigation { get; set; } = null!;

    public virtual Tarjetum Tarjeta { get; set; } = null!;
}
