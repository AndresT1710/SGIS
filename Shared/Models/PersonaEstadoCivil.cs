using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SMI.Shared.Models;

public partial class PersonaEstadoCivil
{
    [Key, ForeignKey("IdPersonaNavigation")]

    public int id_Persona { get; set; }

    public int? id_EstadoCivil { get; set; }

    public virtual EstadoCivil? IdEstadoCivilNavigation { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
