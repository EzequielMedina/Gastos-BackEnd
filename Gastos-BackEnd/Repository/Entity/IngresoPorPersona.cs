using System;
using System.Collections.Generic;

namespace Gastos_BackEnd.Repository.Entity;

public partial class IngresoPorPersona
{
    public Guid Ingresold { get; set; }

    public Guid Personald { get; set; }

    public virtual Ingreso IngresoldNavigation { get; set; } = null!;

    public virtual Persona PersonaldNavigation { get; set; } = null!;
}
