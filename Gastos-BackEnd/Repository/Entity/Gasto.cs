using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gastos_BackEnd.Repository.Entity;

public partial class Gasto
{
    public Guid GastoId { get; set; }

    public decimal Monto { get; set; }

    public DateTime Fecha { get; set; }

    public string NombreGasto { get; set; } = null!;

    public string? Descripcion { get; set; }

    public Guid Personald { get; set; }

    public Guid Categoriald { get; set; }

    public Guid TipoGastold { get; set; }

    [JsonIgnore]
    public virtual Categorium CategorialdNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
    public virtual Persona PersonaldNavigation { get; set; } = null!;
    public virtual TipoGasto TipoGastoldNavigation { get; set; } = null!;
}
