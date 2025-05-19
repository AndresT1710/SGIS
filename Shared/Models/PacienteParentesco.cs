using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class PacienteParentesco
{
    public int IdPaciente { get; set; }

    public int? IdParentesco { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    public virtual Parentesco? IdParentescoNavigation { get; set; }
}
