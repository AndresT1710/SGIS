using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class PersonaSeguroMedico
{
    public int id { get; set; }

    public int? Id_Persona { get; set; }

    public int? Id_SeguroMedico { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual SeguroMedico? IdSeguroMedicoNavigation { get; set; }
}
