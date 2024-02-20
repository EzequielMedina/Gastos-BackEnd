using System;
using System.Collections.Generic;

namespace Gastos_BackEnd.Repository.Entity;

public partial class Ingreso
{
    public Guid Ingresold { get; set; }

    public decimal Monto { get; set; }

    public DateTime Fecha { get; set; }

    public string? Descripcion { get; set; }
}
