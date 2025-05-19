using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMI.Shared.Models;

public partial class Persona
{
    [Key]
    public int id { get; set; }

    public int? id_Genero { get; set; }

    public string? nombre { get; set; }

    public string? apellido { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Correo { get; set; }

    [ForeignKey(nameof(id_Genero))]
    public virtual Genero? IdGeneroNavigation { get; set; }

    //public virtual PersonaProfesion IdNavigation { get; set; } = null!;

    //public virtual Paciente? Paciente { get; set; }

    //public virtual PersonaActividadLaboral? PersonaActividadLaboral { get; set; }

    public virtual PersonaDireccion? PersonaDireccion { get; set; }

    public virtual ICollection<PersonaDocumento> PersonaDocumentos { get; set; } = new List<PersonaDocumento>();

    public List<PersonaEstadoCivil> PersonaEstadoCivil { get; set; }

    // public virtual PersonaGrupoSanguineo? PersonaGrupoSanguineo { get; set; }

    //public virtual PersonaInstruccion? PersonaInstruccion { get; set; }

    public virtual ICollection<PersonaLateralidad> PersonaLateralidad { get; set; } = new List<PersonaLateralidad>();

    public virtual PersonaLugarResidencia? PersonaLugarResidencia { get; set; }

    public virtual ICollection<PersonaReligion>? PersonaReligion { get; set; }

    public virtual ICollection<PersonaSeguroMedico> PersonaSeguroMedicos { get; set; } = new List<PersonaSeguroMedico>();

    public virtual PersonaTelefono? PersonaTelefono { get; set; }

    public virtual ProfesionalSalud? ProfesionalSalud { get; set; }

   // public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
