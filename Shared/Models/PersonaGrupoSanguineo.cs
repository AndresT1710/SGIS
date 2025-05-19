using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class PersonaGrupoSanguineo
{
    public int IdPersona { get; set; }

    public int? IdGrupoSanguineo { get; set; }

    public virtual GrupoSanguineo? IdGrupoSanguineoNavigation { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
