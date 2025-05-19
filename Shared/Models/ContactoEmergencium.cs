using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class ContactoEmergencium
{
    public int Id { get; set; }

    public int IdPaciente { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
