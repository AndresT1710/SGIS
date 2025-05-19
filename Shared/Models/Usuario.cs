using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public int? IdPersona { get; set; }

    public string? Clave { get; set; }

    public bool? Activo { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
