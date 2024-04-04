using System;
using System.Collections.Generic;

namespace Gastos_BackEnd.Repository.Entity;

public partial class Persona
{
    public Guid Personald { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!; 
    public string Contrasena { get; set; } = null!;
    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
}
