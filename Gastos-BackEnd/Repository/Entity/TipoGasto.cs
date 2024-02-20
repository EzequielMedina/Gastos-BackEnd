using System;
using System.Collections.Generic;

namespace Gastos_BackEnd.Repository.Entity;

public partial class TipoGasto
{
    public Guid TipoGastold { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
}
