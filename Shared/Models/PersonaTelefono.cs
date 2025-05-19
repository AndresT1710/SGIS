using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SMI.Shared.Models;

public partial class PersonaTelefono
{
    [Key, ForeignKey("IdPersonaNavigation")]

    public int id_Persona { get; set; }

    public string? celular { get; set; }

    public string? convencional { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
