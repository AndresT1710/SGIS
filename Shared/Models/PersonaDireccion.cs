﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; // <--- ESTE
using System.ComponentModel.DataAnnotations.Schema;


namespace SMI.Shared.Models;

public partial class PersonaDireccion
{
    [Key, ForeignKey("IdPersonaNavigation")]
    public int id_Persona { get; set; }

    public string? callePrincipal { get; set; }

    public string? calleSecundaria1 { get; set; }

    public string? calleSecundaria2 { get; set; }

    public string?numeroCasa { get; set; }

    public string? referencia { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
