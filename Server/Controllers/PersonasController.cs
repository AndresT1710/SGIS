using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMI.Server.Data;
using SMI.Shared.DTOs;
using SMI.Shared.Models;

namespace SMI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly SGISDbContext _context;

        public PersonasController(SGISDbContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDTO>>> GetPersonas()
        {
            var personas = await _context.Personas
                .Include(p => p.PersonaDireccion)
                .Include(p => p.PersonaTelefono)
                .Include(p => p.PersonaSeguroMedicos)
                .ThenInclude(psm => psm.IdSeguroMedicoNavigation)
                .Include(p => p.PersonaEstadoCivil)
                .ThenInclude(pec => pec.IdEstadoCivilNavigation)
                .Include(p => p.PersonaDocumentos)
                .ThenInclude(pd => pd.IdTipoDocumentoNavigation)
                .Include(p => p.PersonaLateralidad)
                .ThenInclude(pl => pl.IdLateralidadNavigation)
                .Include(p => p.PersonaReligion)
                .ThenInclude(pr => pr.IdReligionNavigation)
                .Include(p => p.PersonaLugarResidencia)
                .ThenInclude(plr => plr.IdCiudadNavigation)
                .ThenInclude(plr => plr.IdProvinciaNavigation)
                .Include(p => p.ProfesionalSalud)
                .ThenInclude(ps => ps.IdTipoProfesionalNavigation)
                .ToListAsync();

            return personas.Select(p => PersonaMapper.ToDto(p)).ToList();
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDTO>> GetPersona(int id)
        {
            var persona = await _context.Personas
                .Include(p => p.PersonaDireccion)
                .Include(p => p.PersonaTelefono)
                .Include(p => p.PersonaSeguroMedicos)
                .ThenInclude(psm => psm.IdSeguroMedicoNavigation)
                .Include(p => p.PersonaEstadoCivil)
                .ThenInclude(pec => pec.IdEstadoCivilNavigation)
                .Include(p => p.PersonaDocumentos)
                .ThenInclude(pd => pd.IdTipoDocumentoNavigation)
                .Include(p => p.PersonaLateralidad)
                .ThenInclude(pl => pl.IdLateralidadNavigation)
                .Include(p => p.PersonaReligion)
                .ThenInclude(pr => pr.IdReligionNavigation)
                .Include(p => p.PersonaLugarResidencia)
                .ThenInclude(plr => plr.IdCiudadNavigation)
                .ThenInclude(plr => plr.IdProvinciaNavigation)
                .Include(p => p.ProfesionalSalud)
                .ThenInclude(ps => ps.IdTipoProfesionalNavigation)
                .FirstOrDefaultAsync(p => p.id == id);

            if (persona == null)
                return NotFound();

            return PersonaMapper.ToDto(persona);
        }

        // PUT: api/Personas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, PersonaDTO personaDto)
        {
            if (personaDto == null)
                return BadRequest();

            var personaExistente = await _context.Personas
                .Include(p => p.PersonaDireccion)
                .FirstOrDefaultAsync(p => p.id == id);

            if (personaExistente == null)
                return NotFound();

            // Actualizar los campos
            personaExistente.id_Genero = personaDto.id_Genero;
            personaExistente.nombre = personaDto.nombre;
            personaExistente.apellido = personaDto.apellido;
            personaExistente.FechaNacimiento = personaDto.FechaNacimiento;
            personaExistente.Correo = personaDto.Correo;

            if (personaDto.Direccion != null)
            {
                if (personaExistente.PersonaDireccion == null)
                    personaExistente.PersonaDireccion = new PersonaDireccion();

                personaExistente.PersonaDireccion.callePrincipal = personaDto.Direccion.FirstOrDefault()?.CallePrincipal;
                personaExistente.PersonaDireccion.calleSecundaria1 = personaDto.Direccion.FirstOrDefault()?.CalleSecundaria1;
                personaExistente.PersonaDireccion.calleSecundaria2 = personaDto.Direccion.FirstOrDefault()?.CalleSecundaria2;
                personaExistente.PersonaDireccion.numeroCasa = personaDto.Direccion.FirstOrDefault()?.NumeroCasa;
                personaExistente.PersonaDireccion.referencia = personaDto.Direccion.FirstOrDefault()?.Referencia;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Personas
        [HttpPost]
        public async Task<ActionResult<PersonaDTO>> PostPersona([FromBody] PersonaDTO personaDto)
        {
            var persona = new Persona
            {
                id_Genero = personaDto.id_Genero,
                nombre = personaDto.nombre,
                apellido = personaDto.apellido,
                FechaNacimiento = personaDto.FechaNacimiento,
                Correo = personaDto.Correo,
                PersonaDireccion = personaDto.Direccion?.FirstOrDefault() != null
                    ? new PersonaDireccion
                    {
                        callePrincipal = personaDto.Direccion.First().CallePrincipal,
                        calleSecundaria1 = personaDto.Direccion.First().CalleSecundaria1,
                        calleSecundaria2 = personaDto.Direccion.First().CalleSecundaria2,
                        numeroCasa = personaDto.Direccion.First().NumeroCasa,
                        referencia = personaDto.Direccion.First().Referencia
                    } : null,
                PersonaTelefono = personaDto.Telefono != null ? new PersonaTelefono
                {
                    celular = personaDto.Telefono.Celular,
                    convencional = personaDto.Telefono.Convencional
                } : null
            };
            //Guardar la Persona
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            //Añadir los estados civiles
            if (personaDto.EstadosCiviles != null && personaDto.EstadosCiviles.Any())
            {
                persona.PersonaEstadoCivil = personaDto.EstadosCiviles
                    .Select(ec => new PersonaEstadoCivil
                    {
                        id_Persona = persona.id,
                        id_EstadoCivil = ec.id
                    }).ToList();

                _context.PersonaEstadoCivils.AddRange(persona.PersonaEstadoCivil);
                await _context.SaveChangesAsync();
            }

            //Añadir los seguros médicos
            if (personaDto.SegurosMedicos != null && personaDto.SegurosMedicos.Any())
            {
                persona.PersonaSeguroMedicos = personaDto.SegurosMedicos
                    .Select(sm => new PersonaSeguroMedico
                    {
                        Id_Persona = persona.id,
                        Id_SeguroMedico = sm.id
                    }).ToList();
                _context.PersonaSeguroMedicos.AddRange(persona.PersonaSeguroMedicos);
                await _context.SaveChangesAsync();
            }

            //Añadir documentos si existen
            if (personaDto.Documentos != null && personaDto.Documentos.Any())
            {
                persona.PersonaDocumentos = personaDto.Documentos
                    .Select(doc => new PersonaDocumento
                    {
                        id_Persona = persona.id,
                        id_TipoDocumento = doc.id_TipoDocumento,
                        numeroDocumento = doc.numeroDocumento
                    }).ToList();
                _context.PersonaDocumentos.AddRange(persona.PersonaDocumentos);

                await _context.SaveChangesAsync();
            }

            //Añadir Lateralidad
            if (personaDto.Lateralidades != null && personaDto.Lateralidades.Any())
            {
                persona.PersonaLateralidad = personaDto.Lateralidades
                    .Select(l => new PersonaLateralidad
                    {
                        id_Persona = persona.id,
                        id_Lateralidad = l.id_Lateralidad,
                        
                    }).ToList();

                _context.PersonaLateralidads.AddRange(persona.PersonaLateralidad);
                await _context.SaveChangesAsync();
            }

            // Añadir Religiones
            if (personaDto.Religiones != null && personaDto.Religiones.Any())
            {
                persona.PersonaReligion = personaDto.Religiones
                    .Select(r => new PersonaReligion
                    {
                        id_Persona = persona.id,
                        id_Religion = r.id
                    }).ToList();

                _context.PersonaReligions.AddRange(persona.PersonaReligion);
                await _context.SaveChangesAsync();
            }

            //Añadir Lugar de Residencia
            if (personaDto.LugarResidencia != null && personaDto.LugarResidencia.id_Ciudad.HasValue)
            {
                persona.PersonaLugarResidencia = new PersonaLugarResidencia
                {
                    id_Persona = persona.id,
                    id_Ciudad = personaDto.LugarResidencia.id_Ciudad
                };

                _context.PersonaLugarResidencias.Add(persona.PersonaLugarResidencia);
                await _context.SaveChangesAsync();
            }

            //Añadir Profesional de Salud
            if (personaDto.ProfesionalSalud != null)
            {
                persona.ProfesionalSalud = new ProfesionalSalud
                {
                    id_ProfesionalSalud = persona.id,
                    id_TipoProfesional = personaDto.ProfesionalSalud.id_TipoProfesional,
                    numeroRegistro = personaDto.ProfesionalSalud.numeroRegistro
                };

                _context.ProfesionalSaluds.Add(persona.ProfesionalSalud);
                await _context.SaveChangesAsync();
            }

            //Inclución de las caracteristicas de la persona
            persona = await _context.Personas
                .Include(p => p.PersonaDireccion)
                .Include(p => p.PersonaTelefono)
                .Include(p => p.PersonaEstadoCivil)
                    .ThenInclude(pec => pec.IdEstadoCivilNavigation)
                .Include(p => p.PersonaSeguroMedicos)
                    .ThenInclude(psm => psm.IdSeguroMedicoNavigation)
                .Include(p => p.PersonaDocumentos)
                    .ThenInclude(d => d.IdTipoDocumentoNavigation)
                .Include(p => p.PersonaLateralidad)
                    .ThenInclude(l => l.IdLateralidadNavigation)
                .Include(p => p.PersonaReligion)
                    .ThenInclude(pr => pr.IdReligionNavigation)
                .Include(p => p.PersonaLugarResidencia)
                    .ThenInclude(plr => plr.IdCiudadNavigation)
                    .ThenInclude(plr => plr.IdProvinciaNavigation)
                .Include(p => p.ProfesionalSalud)
                .ThenInclude(ps => ps.IdTipoProfesionalNavigation)

                    .FirstOrDefaultAsync(p => p.id == persona.id);

            //Devolver el DTO Completo
            return CreatedAtAction(nameof(GetPersona), new { id = persona.id }, PersonaMapper.ToDto(persona));
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Personas
                .Include(p => p.PersonaDireccion)
                .FirstOrDefaultAsync(p => p.id == id);

            if (persona == null)
                return NotFound();

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.id == id);
        }
    }
}
