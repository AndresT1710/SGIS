using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class TipoDocumento
{
    public int id { get; set; }

    public string? nombre { get; set; }

    public virtual ICollection<PersonaDocumento> PersonaDocumentos { get; set; } = new List<PersonaDocumento>();
}
