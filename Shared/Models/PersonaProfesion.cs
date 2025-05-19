using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class PersonaProfesion
{
    public int IdPersona { get; set; }

    public int? IdProfesion { get; set; }

    public virtual Profesion? IdProfesionNavigation { get; set; }

    public virtual Persona? Persona { get; set; }
}
