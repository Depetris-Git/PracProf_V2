﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebITSC.DB.Data;

#nullable disable

namespace WebITSC.DB.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241207204513_AbreviaturaCarrera")]
    partial class AbreviaturaCarrera
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Analitico")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CUIL")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("CUS")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ConstanciaCUIL")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoCarnet")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FotocopiaDNI")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("LocalidadId")
                        .HasColumnType("int");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<string>("PartidaNacimiento")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("int");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TituloBase")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("LocalidadId");

                    b.HasIndex("PaisId");

                    b.HasIndex("ProvinciaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Carrera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abreviatura")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("DuracionCarrera")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Modalidad")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Carreras");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.CertificadoAlumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.ToTable("CertificadosAlumno");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Clase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("TurnoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "TurnoId" }, "ClasesDeUnTurnoIDX");

                    b.HasIndex(new[] { "TurnoId", "Fecha" }, "Clases_UQ")
                        .IsUnique();

                    b.ToTable("Clases");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.ClaseAsistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Asistencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("ClaseId")
                        .HasColumnType("int");

                    b.Property<int>("CursadoMateriaId")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CursadoMateriaId" }, "AsistenciasDeAlumnoEnTurnoIDX");

                    b.HasIndex(new[] { "ClaseId" }, "AsistenciasDeUnaClaseIDX");

                    b.HasIndex(new[] { "Asistencia", "ClaseId" }, "FaltaronEstaClaseIDX");

                    b.ToTable("ClaseAsistencias");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Correlatividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MateriaCorrelativaId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaEnPlanEstudioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MateriaCorrelativaId");

                    b.HasIndex("MateriaEnPlanEstudioId");

                    b.ToTable("Correlatividades");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.CursadoMateria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("Anno")
                        .HasColumnType("int");

                    b.Property<string>("CondicionActual")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<int>("TurnoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("VencimientoCondicion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("TurnoId");

                    b.ToTable("CursadosMateria");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Evaluacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Folio")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Libro")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Sede")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TipoEvaluacion")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("TurnoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "TurnoId" }, "EvaluacionesDeUnTurnoIDX");

                    b.HasIndex(new[] { "TurnoId", "Fecha" }, "EvaluacionesEnFechaIDX");

                    b.HasIndex(new[] { "TurnoId", "TipoEvaluacion" }, "EvaluacionesTipoIDX");

                    b.ToTable("Evaluaciones");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.InscripcionCarrera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("CarreraId")
                        .HasColumnType("int");

                    b.Property<int>("Cohorte")
                        .HasColumnType("int");

                    b.Property<string>("EstadoAlumno")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Legajo")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("LibroMatriz")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NroOrdenAlumno")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CarreraId", "Cohorte" }, "CohorteIDX");

                    b.HasIndex(new[] { "AlumnoId", "CarreraId", "Cohorte" }, "InscripcionCarrera_UQ")
                        .IsUnique();

                    b.ToTable("InscripcionesCarrera");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Localidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Localidades");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Anno")
                        .HasColumnType("int");

                    b.Property<string>("Formacion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Formato")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Nombre" }, "MateriasPorNombreIDX");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.MateriaEnPlanEstudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Anno")
                        .HasColumnType("int");

                    b.Property<string>("Anual_Cuatrimestral")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("HrsCatedraSemanales")
                        .HasColumnType("int");

                    b.Property<int>("HrsRelojAnuales")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroOrden")
                        .HasColumnType("int");

                    b.Property<int>("PlanEstudioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.HasIndex(new[] { "PlanEstudioId", "MateriaId" }, "MateriaEnPlanEstudio_UQ")
                        .IsUnique();

                    b.ToTable("MateriasEnPlanEstudio");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Asistencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("CursadoMateriaId")
                        .HasColumnType("int");

                    b.Property<int>("EvaluacionId")
                        .HasColumnType("int");

                    b.Property<int>("ValorNota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CursadoMateriaId" }, "NotasDeAlumnoEnMateriaIDX");

                    b.HasIndex(new[] { "EvaluacionId" }, "NotasDeEvaluacionIDX");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoDocumentoId");

                    b.HasIndex(new[] { "Apellido", "Nombre" }, "Apellido-NombreIDX");

                    b.HasIndex(new[] { "Nombre", "Apellido" }, "Nombre-ApellidoIDX");

                    b.HasIndex(new[] { "Documento", "TipoDocumentoId" }, "PersonaUnica_UQ")
                        .IsUnique();

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.PlanEstudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Anno")
                        .HasColumnType("int");

                    b.Property<int>("CarreraId")
                        .HasColumnType("int");

                    b.Property<bool>("EstadoPlan")
                        .HasColumnType("bit");

                    b.Property<string>("ResolucionMinisterial")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CarreraId", "Anno" }, "PlanEstudio_UQ")
                        .IsUnique();

                    b.HasIndex(new[] { "CarreraId" }, "PlanesDeUnaCarreraIDX");

                    b.ToTable("PlanesEstudio");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Codigo" }, "TDocumentoUnico_UQ")
                        .IsUnique();

                    b.ToTable("TiposDocumento");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnnoCicloLectivo")
                        .HasColumnType("int");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("MateriaEnPlanEstudioId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfesorId")
                        .HasColumnType("int");

                    b.Property<string>("Sede")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.HasIndex("ProfesorId");

                    b.HasIndex(new[] { "MateriaEnPlanEstudioId", "Sede", "Horario", "AnnoCicloLectivo" }, "InscripcionCarrera_UQ")
                        .IsUnique();

                    b.HasIndex(new[] { "MateriaEnPlanEstudioId", "ProfesorId" }, "MateriasQueDaUnProfeIDX");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Alumno", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebITSC.DB.Data.Entity.Localidad", "Localidad")
                        .WithMany()
                        .HasForeignKey("LocalidadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebITSC.DB.Data.Entity.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebITSC.DB.Data.Entity.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("ProvinciaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebITSC.DB.Data.Entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Localidad");

                    b.Navigation("Pais");

                    b.Navigation("Provincia");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.CertificadoAlumno", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Alumno", "Alumno")
                        .WithMany("CertificadosAlumno")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Alumno");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Clase", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Turno", "Turno")
                        .WithMany("Clases")
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.ClaseAsistencia", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Clase", "Clase")
                        .WithMany()
                        .HasForeignKey("ClaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebITSC.DB.Data.Entity.CursadoMateria", "CursadoMateria")
                        .WithMany("ClaseAsistencias")
                        .HasForeignKey("CursadoMateriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Clase");

                    b.Navigation("CursadoMateria");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Correlatividad", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.MateriaEnPlanEstudio", "MateriaCorrelativa")
                        .WithMany()
                        .HasForeignKey("MateriaCorrelativaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebITSC.DB.Data.Entity.MateriaEnPlanEstudio", "MateriaEnPlanEstudio")
                        .WithMany()
                        .HasForeignKey("MateriaEnPlanEstudioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MateriaCorrelativa");

                    b.Navigation("MateriaEnPlanEstudio");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.CursadoMateria", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Alumno", "Alumno")
                        .WithMany("MateriasCursadas")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebITSC.DB.Data.Entity.Turno", "Turno")
                        .WithMany("AlumnosCursando")
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Departamento", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Provincia", "Provincia")
                        .WithMany("Departamentos")
                        .HasForeignKey("ProvinciaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Evaluacion", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Turno", "Turno")
                        .WithMany()
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.InscripcionCarrera", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Alumno", "Alumno")
                        .WithMany("InscripcionesCarreras")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebITSC.DB.Data.Entity.Carrera", "Carrera")
                        .WithMany("InscripcionesCarrera")
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Carrera");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Localidad", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Departamento", "Departamento")
                        .WithMany("Localidades")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.MateriaEnPlanEstudio", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebITSC.DB.Data.Entity.PlanEstudio", "PlanEstudio")
                        .WithMany()
                        .HasForeignKey("PlanEstudioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Materia");

                    b.Navigation("PlanEstudio");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Nota", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.CursadoMateria", "CursadoMateria")
                        .WithMany("Notas")
                        .HasForeignKey("CursadoMateriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebITSC.DB.Data.Entity.Evaluacion", "Evaluacion")
                        .WithMany("Notas")
                        .HasForeignKey("EvaluacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CursadoMateria");

                    b.Navigation("Evaluacion");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Persona", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.TipoDocumento", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.PlanEstudio", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Carrera", "Carrera")
                        .WithMany()
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Carrera");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Profesor", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Provincia", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Pais", "Pais")
                        .WithMany("Provincias")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Turno", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.MateriaEnPlanEstudio", "MateriaEnPlanEstudio")
                        .WithMany()
                        .HasForeignKey("MateriaEnPlanEstudioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebITSC.DB.Data.Entity.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorId");

                    b.Navigation("MateriaEnPlanEstudio");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Usuario", b =>
                {
                    b.HasOne("WebITSC.DB.Data.Entity.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Alumno", b =>
                {
                    b.Navigation("CertificadosAlumno");

                    b.Navigation("InscripcionesCarreras");

                    b.Navigation("MateriasCursadas");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Carrera", b =>
                {
                    b.Navigation("InscripcionesCarrera");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.CursadoMateria", b =>
                {
                    b.Navigation("ClaseAsistencias");

                    b.Navigation("Notas");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Departamento", b =>
                {
                    b.Navigation("Localidades");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Evaluacion", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Pais", b =>
                {
                    b.Navigation("Provincias");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Provincia", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("WebITSC.DB.Data.Entity.Turno", b =>
                {
                    b.Navigation("AlumnosCursando");

                    b.Navigation("Clases");
                });
#pragma warning restore 612, 618
        }
    }
}
