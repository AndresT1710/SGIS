using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class PersonaReligion
{
    public int id_Persona { get; set; }

    public int? id_Religion { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual Religion? IdReligionNavigation { get; set; }
}
