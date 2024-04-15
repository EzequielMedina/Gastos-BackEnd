using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gastos_BackEnd.Repository.Entity;

public partial class IngresoPorPersona
{
    [Key]
    public Guid Ingresold { get; set; }

    [Key]
    public Guid Personald { get; set; }

    public virtual Ingreso IngresoldNavigation { get; set; } = null!;

    public virtual Persona PersonaldNavigation { get; set; } = null!;
}
