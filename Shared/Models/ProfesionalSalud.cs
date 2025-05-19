using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class ProfesionalSalud
{
    public int id_ProfesionalSalud { get; set; }

    public int? id_TipoProfesional { get; set; }

    public string? numeroRegistro { get; set; }

    public virtual Persona IdProfesionalSaludNavigation { get; set; } = null!;

    public virtual TipoProfesionalSalud? IdTipoProfesionalNavigation { get; set; }
}
