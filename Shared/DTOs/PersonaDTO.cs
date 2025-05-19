using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMI.Shared.DTOs
{
    public class PersonaDTO
    {
        public int? id_Genero { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Correo { get; set; }

        //DIRECCION
        public List<PersonaDireccionDTO>? Direccion { get; set; }

        //TELEFONO
        public PersonaTelefonoDTO? Telefono { get; set; }

        //ESTADO CIVIL
        public List<EstadoCivilDTO>? EstadosCiviles { get; set; }
    
        //SEGUROMEDICO
        public List<SeguroMedicoDTO>? SegurosMedicos { get; set; }

        //DOCUMENTOS
        public List<PersonaDocumentoDTO>? Documentos { get; set; }

        //LATERALIDAD
        public List<PersonaLateralidadDTO>? Lateralidades { get; set; }

        //RELIGION
        public List<ReligionDTO>? Religiones { get; set; }

        //LUGAR DE RESIDENCIA
        public PersonaLugarResidenciaDTO? LugarResidencia { get; set; }

        //PROFESIONAL DE SALUD
        public ProfesionalSaludDTO? ProfesionalSalud { get; set; }
    }
}
