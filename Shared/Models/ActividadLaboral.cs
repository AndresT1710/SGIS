using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class ActividadLaboral
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<PersonaActividadLaboral> PersonaActividadLaborals { get; set; } = new List<PersonaActividadLaboral>();
}
