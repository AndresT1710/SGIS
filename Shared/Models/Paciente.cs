using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class Paciente
{
    public int IdPersona { get; set; }

    public virtual ICollection<ContactoEmergencium> ContactoEmergencia { get; set; } = new List<ContactoEmergencium>();

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual PacienteParentesco? PacienteParentesco { get; set; }
}
