using SMI.Shared.DTOs;
using SMI.Shared.Models;

public static class PersonaMapper
{
    public static PersonaDTO ToDto(Persona persona)
    {
        return new PersonaDTO
        {
            id_Genero = persona.id_Genero,
            nombre = persona.nombre,
            apellido = persona.apellido,
            FechaNacimiento = persona.FechaNacimiento,
            Correo = persona.Correo,
            Direccion = persona.PersonaDireccion != null
                ? new List<PersonaDireccionDTO>
                {
                    new PersonaDireccionDTO
                    {
                        CallePrincipal = persona.PersonaDireccion.callePrincipal,
                        CalleSecundaria1 = persona.PersonaDireccion.calleSecundaria1,
                        CalleSecundaria2 = persona.PersonaDireccion.calleSecundaria2,
                        NumeroCasa = persona.PersonaDireccion.numeroCasa,
                        Referencia = persona.PersonaDireccion.referencia
                    }
                }
                : null,
            Telefono = persona.PersonaTelefono != null
                ? new PersonaTelefonoDTO
                {
                    Convencional = persona.PersonaTelefono.convencional,
                    Celular = persona.PersonaTelefono.celular
                }
                : null,
            EstadosCiviles = persona.PersonaEstadoCivil?
            .Where(pec => pec.IdEstadoCivilNavigation != null)
            .Select(pec => new EstadoCivilDTO
            {
                id = pec.IdEstadoCivilNavigation!.id,
                nombre = pec.IdEstadoCivilNavigation.nombre
            }).ToList(),

            SegurosMedicos = persona.PersonaSeguroMedicos?
            .Where(psm => psm.IdSeguroMedicoNavigation != null)
            .Select(pms => new SeguroMedicoDTO
            {
                id = pms.IdSeguroMedicoNavigation!.id,
                nombre = pms.IdSeguroMedicoNavigation.nombre,
            }).ToList(),

            Documentos = persona.PersonaDocumentos ?
            .Select(doc => new PersonaDocumentoDTO
            {
                id_Persona = doc.id_Persona,
                id_TipoDocumento = doc.id_TipoDocumento,
                nombreTipoDocumento = doc.IdTipoDocumentoNavigation?.nombre,
                numeroDocumento = doc.numeroDocumento
            }).ToList(),

            Lateralidades = persona.PersonaLateralidad?
            .Select(l => new PersonaLateralidadDTO
            {
                id_Persona = l.id_Persona,
                id_Lateralidad = l.id_Lateralidad,
                nombreLateralidad = l.IdLateralidadNavigation?.nombre
            }).ToList(),

            Religiones = persona.PersonaReligion?
            .Where(r => r.IdReligionNavigation != null)
            .Select(r => new ReligionDTO
            {
                id = r.IdReligionNavigation.id,
                nombre = r.IdReligionNavigation.nombre
            }).ToList(),

            LugarResidencia = persona.PersonaLugarResidencia != null
                ? new PersonaLugarResidenciaDTO
                {
                    id_Ciudad = persona.PersonaLugarResidencia.id_Ciudad,
                    nombreCiudad = persona.PersonaLugarResidencia.IdCiudadNavigation?.nombre,
                    id_Provincia = persona.PersonaLugarResidencia.IdCiudadNavigation?.IdProvinciaNavigation?.id,
                    nombreProvincia = persona.PersonaLugarResidencia.IdCiudadNavigation?.IdProvinciaNavigation?.nombre
                }
                : null,

            ProfesionalSalud = persona.ProfesionalSalud != null ? new ProfesionalSaludDTO
            {
                id_ProfesionalSalud = persona.ProfesionalSalud.id_ProfesionalSalud,
                id_TipoProfesional = persona.ProfesionalSalud.id_TipoProfesional,
                numeroRegistro = persona.ProfesionalSalud.numeroRegistro,
                nombreTipoProfesional = persona.ProfesionalSalud.IdTipoProfesionalNavigation?.nombre
            } : null


        };
    }
}
