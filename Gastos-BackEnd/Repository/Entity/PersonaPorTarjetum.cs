using Gastos_BackEnd.Repository.Entity;
using System;
using System.Collections.Generic;

namespace Gastos_BackEnd.Entity;

public partial class PersonaPorTarjetum
{
    public Guid PersonaId { get; set; }

    public Guid TarjetaId { get; set; }

    public Guid PersonaPorTarjetaId { get; set; }

    public virtual Persona Persona { get; set; } = null!;

    public virtual Tarjetum Tarjeta { get; set; } = null!;
}
