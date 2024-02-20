using System;
using System.Collections.Generic;

namespace Gastos_BackEnd.Repository.Entity;

public partial class Periodo
{
    public Guid Periodold { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Monto { get; set; }

    public Guid TarjetaId { get; set; }

    public virtual Tarjetum Tarjeta { get; set; } = null!;
}
