using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class GrupoSanguineo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<PersonaGrupoSanguineo> PersonaGrupoSanguineos { get; set; } = new List<PersonaGrupoSanguineo>();
}
