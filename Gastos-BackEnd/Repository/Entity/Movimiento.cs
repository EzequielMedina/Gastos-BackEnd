using System;
using System.Collections.Generic;

namespace Gastos_BackEnd.Repository.Entity;

public partial class Movimiento
{
    public Guid Movimientold { get; set; }

    public decimal MontoTotal { get; set; }

    public DateTime Fecha { get; set; }

    public string? Descripcion { get; set; }

    public Guid GastoId { get; set; }

    public virtual Gasto Gasto { get; set; } = null!;
}
