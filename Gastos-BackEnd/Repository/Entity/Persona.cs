using Gastos_BackEnd.Entity;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gastos_BackEnd.Repository.Entity;

public partial class Persona
{
    public Guid Personald { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    [JsonIgnore]
    public string Contrasena { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    [JsonIgnore]

    public virtual ICollection<PersonaPorTarjetum> PersonaPorTarjeta { get; set; } = new List<PersonaPorTarjetum>();

}
