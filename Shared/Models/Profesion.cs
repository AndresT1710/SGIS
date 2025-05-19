using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class Profesion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<PersonaProfesion> PersonaProfesions { get; set; } = new List<PersonaProfesion>();
}
