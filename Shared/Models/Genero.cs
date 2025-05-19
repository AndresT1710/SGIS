using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class Genero
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
