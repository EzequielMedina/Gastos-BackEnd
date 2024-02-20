using System;
using System.Collections.Generic;

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

    public Guid? TarjetaId { get; set; }

    public virtual Categorium CategorialdNavigation { get; set; } = null!;

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual Persona PersonaldNavigation { get; set; } = null!;

    public virtual Tarjetum? Tarjeta { get; set; }

    public virtual TipoGasto TipoGastoldNavigation { get; set; } = null!;
}
