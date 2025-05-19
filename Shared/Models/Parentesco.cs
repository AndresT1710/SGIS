using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class Parentesco
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<PacienteParentesco> PacienteParentescos { get; set; } = new List<PacienteParentesco>();
}
