using Gastos_BackEnd.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gastos_BackEnd.Repository.Entity;

[Table("Tarjeta")]
public partial class Tarjetum
{
    [Key]
    public Guid TarjetaId { get; set; }

    public string Nombre { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<PersonaPorTarjetum> PersonaPorTarjeta { get; set; } = null;

}
