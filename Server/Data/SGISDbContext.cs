using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SMI.Shared.Models;

namespace SMI.Server.Data;

public partial class SGISDbContext : DbContext
{
    public SGISDbContext()
    {
    }

    public SGISDbContext(DbContextOptions<SGISDbContext> options)
        : base(options)
    {
    }

    //public virtual DbSet<ActividadLaboral> ActividadLaborals { get; set; }

    public virtual DbSet<Ciudad> Ciudades { get; set; }

    //public virtual DbSet<ContactoEmergencium> ContactoEmergencia { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }

    //public virtual DbSet<Genero> Generos { get; set; }

    //public virtual DbSet<GrupoSanguineo> GrupoSanguineos { get; set; }

    public virtual DbSet<Lateralidad> Lateralidads { get; set; }

    //public virtual DbSet<NivelInstruccion> NivelInstruccions { get; set; }

    //public virtual DbSet<Paciente> Pacientes { get; set; }

    //public virtual DbSet<PacienteParentesco> PacienteParentescos { get; set; }

    //public virtual DbSet<Parentesco> Parentescos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    //public virtual DbSet<PersonaActividadLaboral> PersonaActividadLaborals { get; set; }

    public virtual DbSet<PersonaDireccion> PersonaDireccions { get; set; }

    public virtual DbSet<PersonaDocumento> PersonaDocumentos { get; set; }

    public virtual DbSet<PersonaEstadoCivil> PersonaEstadoCivils { get; set; }

    //public virtual DbSet<PersonaGrupoSanguineo> PersonaGrupoSanguineos { get; set; }

    //public virtual DbSet<PersonaInstruccion> PersonaInstruccions { get; set; }

    public virtual DbSet<PersonaLateralidad> PersonaLateralidads { get; set; }

    public virtual DbSet<PersonaLugarResidencia> PersonaLugarResidencias { get; set; }

    //public virtual DbSet<PersonaProfesion> PersonaProfesions { get; set; }

    public virtual DbSet<PersonaReligion> PersonaReligions { get; set; }

    public virtual DbSet<PersonaSeguroMedico> PersonaSeguroMedicos { get; set; }

    public virtual DbSet<PersonaTelefono> PersonaTelefonos { get; set; }

    //public virtual DbSet<Profesion> Profesions { get; set; }

    public virtual DbSet<ProfesionalSalud> ProfesionalSaluds { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<SeguroMedico> SeguroMedicos { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoProfesionalSalud> TipoProfesionalSaluds { get; set; }

    //public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

      //  modelBuilder.Entity<ActividadLaboral>(entity =>
        //{
         //   entity.ToTable("ActividadLaboral");

           // entity.Property(e => e.Id).HasColumnName("id");
            //entity.Property(e => e.Nombre)
              //  .HasMaxLength(100)
                //.HasColumnName("nombre");
        //});

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.ToTable("Ciudad");

            entity.Property(e => e.id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.id_Provincia).HasColumnName("id_Provincia");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.id_Provincia)
                .HasConstraintName("FK_Ciudad_Provincia");
        });
        /*
        modelBuilder.Entity<ContactoEmergencium>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.IdPaciente).HasColumnName("id_Paciente");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.ContactoEmergencia)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactoEmergencia_Paciente");
        });
       */
        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.ToTable("EstadoCivil");

            entity.Property(e => e.id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.ToTable("Genero");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });
        /*

        modelBuilder.Entity<GrupoSanguineo>(entity =>
        {
            entity.ToTable("GrupoSanguineo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });
        */
        modelBuilder.Entity<Lateralidad>(entity =>
        {
            entity.ToTable("Lateralidad");

            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });
        /*
        modelBuilder.Entity<NivelInstruccion>(entity =>
        {
            entity.ToTable("NivelInstruccion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPersona);

            entity.ToTable("Paciente");

            entity.Property(e => e.IdPersona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");

            entity.HasOne(d => d.IdPersonaNavigation).WithOne(p => p.Paciente)
                .HasForeignKey<Paciente>(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Persona");
        });

        modelBuilder.Entity<PacienteParentesco>(entity =>
        {
            entity.HasKey(e => e.IdPaciente);

            entity.ToTable("PacienteParentesco");

            entity.Property(e => e.IdPaciente)
                .ValueGeneratedNever()
                .HasColumnName("id_Paciente");
            entity.Property(e => e.IdParentesco).HasColumnName("id_Parentesco");

            entity.HasOne(d => d.IdPacienteNavigation).WithOne(p => p.PacienteParentesco)
                .HasForeignKey<PacienteParentesco>(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PacienteParentesco_Paciente");

            entity.HasOne(d => d.IdParentescoNavigation).WithMany(p => p.PacienteParentescos)
                .HasForeignKey(d => d.IdParentesco)
                .HasConstraintName("FK_PacienteParentesco_Parentesco");
        });

        modelBuilder.Entity<Parentesco>(entity =>
        {
            entity.ToTable("Parentesco");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });*/

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.ToTable("Persona");

            entity.Property(e => e.id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo).HasMaxLength(255);
            entity.Property(e => e.id_Genero).HasColumnName("id_Genero");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(p => p.PersonaDireccion)
            .WithOne(p => p.IdPersonaNavigation)
            .HasForeignKey<PersonaDireccion>(d => d.id_Persona);

           /* entity.HasOne(d => d.IdNavigation).WithOne(p => p.Persona)
                .HasForeignKey<Persona>(d => d.id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_PersonaProfesion");*/

            entity.HasOne(d => d.IdGeneroNavigation)
                .WithMany(p => p.Personas)
                .HasForeignKey(d => d.id_Genero)
                .HasConstraintName("FK_Persona_Genero");
        });

        /*modelBuilder.Entity<PersonaActividadLaboral>(entity =>
        {
            entity.HasKey(e => e.IdPersona);

            entity.ToTable("PersonaActividadLaboral");

            entity.Property(e => e.IdPersona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");
            entity.Property(e => e.IdActividadLaboral).HasColumnName("id_ActividadLaboral");

            entity.HasOne(d => d.IdActividadLaboralNavigation).WithMany(p => p.PersonaActividadLaborals)
                .HasForeignKey(d => d.IdActividadLaboral)
                .HasConstraintName("FK_PersonaActividadLaboral_ActividadLaboral");

            entity.HasOne(d => d.IdPersonaNavigation).WithOne(p => p.PersonaActividadLaboral)
                .HasForeignKey<PersonaActividadLaboral>(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaActividadLaboral_Persona");
        });
        */
        modelBuilder.Entity<PersonaDireccion>(entity =>
        {
            entity.HasKey(e => e.id_Persona);

            entity.ToTable("PersonaDireccion");

            entity.Property(e => e.id_Persona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");
            entity.Property(e => e.callePrincipal)
                .HasMaxLength(100)
                .HasColumnName("callePrincipal");
            entity.Property(e => e.calleSecundaria1)
                .HasMaxLength(100)
                .HasColumnName("calleSecundaria1");
            entity.Property(e => e.calleSecundaria2)
                .HasMaxLength(100)
                .HasColumnName("calleSecundaria2");
            entity.Property(e => e.numeroCasa)
                .HasMaxLength(50)
                .HasColumnName("numeroCasa");
            entity.Property(e => e.referencia)
                .HasMaxLength(100)
                .HasColumnName("referencia");

            entity.HasOne(d => d.IdPersonaNavigation)
            .WithOne(p => p.PersonaDireccion)
                .HasForeignKey<PersonaDireccion>(d => d.id_Persona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDireccion_Persona");
        });
        
        modelBuilder.Entity<PersonaDocumento>(entity =>
        {
            entity.HasKey(e => new { e.id_Persona, e.id_TipoDocumento });

            entity.ToTable("PersonaDocumento");

            entity.Property(e => e.id_Persona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");
            entity.Property(e => e.id_TipoDocumento).HasColumnName("id_TipoDocumento");
            entity.Property(e => e.numeroDocumento)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("numeroDocumento");

            entity.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.PersonaDocumentos)
                .HasForeignKey(d => d.id_Persona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDocumento_Persona");

            entity.HasOne(d => d.IdTipoDocumentoNavigation)
                .WithMany(p => p.PersonaDocumentos)
                .HasForeignKey(d => d.id_TipoDocumento)
                .HasConstraintName("FK_PersonaDocumento_TipoDocumento");
        });
        
        modelBuilder.Entity<PersonaEstadoCivil>(entity =>
        {
            entity.HasKey(e => e.id_Persona);

            entity.ToTable("PersonaEstadoCivil");

            entity.Property(e => e.id_Persona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");
            entity.Property(e => e.id_EstadoCivil).HasColumnName("id_EstadoCivil");

            entity.HasOne(d => d.IdEstadoCivilNavigation).WithMany(p => p.PersonaEstadoCivils)
                .HasForeignKey(d => d.id_EstadoCivil)
                .HasConstraintName("FK_PersonaEstadoCivil_EstadoCivil");

            entity.HasOne(d => d.IdPersonaNavigation)
            .WithMany(p => p.PersonaEstadoCivil)
                .HasForeignKey(d => d.id_Persona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaEstadoCivil_Persona");
        });
        /*
        modelBuilder.Entity<PersonaGrupoSanguineo>(entity =>
        {
            entity.HasKey(e => e.IdPersona);

            entity.ToTable("PersonaGrupoSanguineo");

            entity.Property(e => e.IdPersona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");
            entity.Property(e => e.IdGrupoSanguineo).HasColumnName("id_GrupoSanguineo");

            entity.HasOne(d => d.IdGrupoSanguineoNavigation).WithMany(p => p.PersonaGrupoSanguineos)
                .HasForeignKey(d => d.IdGrupoSanguineo)
                .HasConstraintName("FK_PersonaGrupoSanguineo_GrupoSanguineo");

            entity.HasOne(d => d.IdPersonaNavigation).WithOne(p => p.PersonaGrupoSanguineo)
                .HasForeignKey<PersonaGrupoSanguineo>(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaGrupoSanguineo_Persona");
        });

        modelBuilder.Entity<PersonaInstruccion>(entity =>
        {
            entity.HasKey(e => e.IdPersona);

            entity.ToTable("PersonaInstruccion");

            entity.Property(e => e.IdPersona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");
            entity.Property(e => e.IdNivelInstruccion).HasColumnName("id_NivelInstruccion");

            entity.HasOne(d => d.IdNivelInstruccionNavigation).WithMany(p => p.PersonaInstruccions)
                .HasForeignKey(d => d.IdNivelInstruccion)
                .HasConstraintName("FK_PersonaInstruccion_NivelInstruccion");

            entity.HasOne(d => d.IdPersonaNavigation).WithOne(p => p.PersonaInstruccion)
                .HasForeignKey<PersonaInstruccion>(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaInstruccion_Persona");
        });
        */
        modelBuilder.Entity<PersonaLateralidad>(entity =>
        {
            entity.HasKey(e => new { e.id_Persona, e.id_Lateralidad });

            entity.ToTable("PersonaLateralidad");

            entity.Property(e => e.id_Persona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");
            entity.Property(e => e.id_Lateralidad).HasColumnName("id_Lateralidad");

            entity.HasOne(d => d.IdLateralidadNavigation)
                .WithMany(p => p.PersonaLateralidads)
                .HasForeignKey(d => d.id_Lateralidad)
                .HasConstraintName("FK_PersonaLateralidad_Lateralidad");

            entity.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.PersonaLateralidad)
                .HasForeignKey(d => d.id_Persona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaLateralidad_Persona");
        });
        
        modelBuilder.Entity<PersonaLugarResidencia>(entity =>
        {
            entity.HasKey(e => e.id_Persona);

            entity.ToTable("PersonaLugarResidencia");

            entity.Property(e => e.id_Persona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");
            entity.Property(e => e.id_Ciudad).HasColumnName("id_Ciudad");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.PersonaLugarResidencia)
                .HasForeignKey(d => d.id_Ciudad)
                .HasConstraintName("FK_PersonaLugarResidencia_Ciudad");

            entity.HasOne(d => d.IdPersonaNavigation).WithOne(p => p.PersonaLugarResidencia)
                .HasForeignKey<PersonaLugarResidencia>(d => d.id_Persona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaLugarResidencia_Persona");
        });
        /*
        modelBuilder.Entity<PersonaProfesion>(entity =>
        {
            entity.HasKey(e => e.IdPersona);

            entity.ToTable("PersonaProfesion");

            entity.Property(e => e.IdPersona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");
            entity.Property(e => e.IdProfesion).HasColumnName("id_Profesion");

            entity.HasOne(d => d.IdProfesionNavigation).WithMany(p => p.PersonaProfesions)
                .HasForeignKey(d => d.IdProfesion)
                .HasConstraintName("FK_PersonaProfesion_Profesion");
        });
        */
        modelBuilder.Entity<PersonaReligion>(entity =>
        {
            entity.HasKey(e => e.id_Persona);

            entity.ToTable("PersonaReligion");

            entity.Property(e => e.id_Persona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");
            entity.Property(e => e.id_Religion).HasColumnName("id_Religion");

            entity.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.PersonaReligion)
                .HasForeignKey(d => d.id_Persona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaReligion_Persona");

            entity.HasOne(d => d.IdReligionNavigation).WithMany(p => p.PersonaReligions)
                .HasForeignKey(d => d.id_Religion)
                .HasConstraintName("FK_PersonaReligion_Religion");
        });
        
        modelBuilder.Entity<PersonaSeguroMedico>(entity =>
        {
            entity.ToTable("PersonaSeguroMedico");

            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.Id_Persona).HasColumnName("id_Persona");
            entity.Property(e => e.Id_SeguroMedico).HasColumnName("id_SeguroMedico");

            entity.HasOne(d => d.IdPersonaNavigation)
            .WithMany(p => p.PersonaSeguroMedicos)
                .HasForeignKey(d => d.Id_Persona)
                .HasConstraintName("FK_PersonaSeguroMedico_Persona");

            entity.HasOne(d => d.IdSeguroMedicoNavigation).WithMany(p => p.PersonaSeguroMedicos)
                .HasForeignKey(d => d.Id_SeguroMedico)
                .HasConstraintName("FK_PersonaSeguroMedico_SeguroMedico");
        });
        
        modelBuilder.Entity<PersonaTelefono>(entity =>
        {
            entity.HasKey(e => e.id_Persona);

            entity.ToTable("PersonaTelefono");

            entity.Property(e => e.id_Persona)
                .ValueGeneratedNever()
                .HasColumnName("id_Persona");

            entity.Property(e => e.celular)
                .HasMaxLength(10)
                .HasColumnName("celular");

            entity.Property(e => e.convencional)
                .HasMaxLength(10)
                .HasColumnName("convencional");

            entity.HasOne(d => d.IdPersonaNavigation)
                .WithOne(p => p.PersonaTelefono)
                .HasForeignKey<PersonaTelefono>(d => d.id_Persona)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PersonaTelefono_Persona");
        });
        /*
        modelBuilder.Entity<Profesion>(entity =>
        {
            entity.ToTable("Profesion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });
        */
        modelBuilder.Entity<ProfesionalSalud>(entity =>
        {
            entity.HasKey(e => e.id_ProfesionalSalud);

            entity.ToTable("ProfesionalSalud");

            entity.Property(e => e.id_ProfesionalSalud)
                .ValueGeneratedNever()
                .HasColumnName("id_ProfesionalSalud");
            entity.Property(e => e.id_TipoProfesional).HasColumnName("id_TipoProfesional");
            entity.Property(e => e.numeroRegistro)
                .HasMaxLength(50)
                .HasColumnName("numeroRegistro");

            entity.HasOne(d => d.IdProfesionalSaludNavigation).WithOne(p => p.ProfesionalSalud)
                .HasForeignKey<ProfesionalSalud>(d => d.id_ProfesionalSalud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfesionalSalud_Persona");

            entity.HasOne(d => d.IdTipoProfesionalNavigation).WithMany(p => p.ProfesionalSaluds)
                .HasForeignKey(d => d.id_TipoProfesional)
                .HasConstraintName("FK_ProfesionalSalud_TipoProfesionalSalud");
        });
        
        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.ToTable("Provincia");
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });
        
        modelBuilder.Entity<Religion>(entity =>
        {
            entity.ToTable("Religion");

            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });
        
        modelBuilder.Entity<SeguroMedico>(entity =>
        {
            entity.ToTable("SeguroMedico");

            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });
        
        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.ToTable("TipoDocumento");

            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });
        
        modelBuilder.Entity<TipoProfesionalSalud>(entity =>
        {
            entity.ToTable("TipoProfesionalSalud");

            entity.Property(e => e.id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });
        /*
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07D7BF2511");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave).HasMaxLength(255);
            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_Usuario_Persona");
        });*/

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
