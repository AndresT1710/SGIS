using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class PersonaDocumento
{
    public int id_Persona { get; set; }

    public int? id_TipoDocumento { get; set; }

    public string? numeroDocumento { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual TipoDocumento? IdTipoDocumentoNavigation { get; set; }
}
