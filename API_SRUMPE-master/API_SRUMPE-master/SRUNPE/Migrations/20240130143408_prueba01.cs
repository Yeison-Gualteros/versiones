using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SRUNPE.Migrations
{
    /// <inheritdoc />
    public partial class prueba01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acudiente",
                columns: table => new
                {
                    AcudienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIdentificacion = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelacionConEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acudiente", x => x.AcudienteId);
                });

            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    AsistenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAsistente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaHoraAsistencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UbicacionEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asistio = table.Column<bool>(type: "bit", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencia", x => x.AsistenciaId);
                });

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    AulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreNumero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    TipoAula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoAula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioDisponibilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotasAdicionales = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UltimaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponsableAula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrosIncidentesProblemas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.AulaId);
                });

            migrationBuilder.CreateTable(
                name: "CandidatoEstudiantes",
                columns: table => new
                {
                    CandidatoEstudianteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoPersona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoEstudiantes", x => x.CandidatoEstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "Cupo",
                columns: table => new
                {
                    CupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Duracion = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupo", x => x.CupoId);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Curso = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoAcademico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfesorAsignado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AulasAsignadas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaLimiteInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetodosEnsenanza = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "DireccionAcudiente",
                columns: table => new
                {
                    DireccionAcudienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColoniaBarrio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoProvincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionAcudiente", x => x.DireccionAcudienteId);
                });

            migrationBuilder.CreateTable(
                name: "Estadisticas",
                columns: table => new
                {
                    EstadisticaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Materia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotaPromedio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NotaMaxima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NotaMinima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadExamenes = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AñoEscolar = table.Column<int>(type: "int", nullable: false),
                    PeriodoEscolar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadisticas", x => x.EstadisticaId);
                });

            migrationBuilder.CreateTable(
                name: "EstudianteDocumentos",
                columns: table => new
                {
                    EstudianteDocumentosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDocumento = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tamaño = table.Column<int>(type: "int", nullable: false),
                    CandidatoEstudianteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudianteDocumentos", x => x.EstudianteDocumentosId);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    HorarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    PeriodoAcademico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupoSeccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicioClases = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinClases = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoHorario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuracionClaseMinutos = table.Column<int>(type: "int", nullable: false),
                    SalaAula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfesorAsistente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificacionCambioHorario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.HorarioId);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    MateriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoAcademico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfesorAsignado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModalidadEnsenanza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotasAdicionales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupoSeccionMateria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetodosEnsenanza = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.MateriaId);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    MatriculaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaMatricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoMatricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoMatricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodoAcademico = table.Column<int>(type: "int", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaMatricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformacionPlanEstudios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistroCambios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.MatriculaId);
                });

            migrationBuilder.CreateTable(
                name: "PreMatricula",
                columns: table => new
                {
                    PreMatriculaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradoONivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoPreMatricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequisitosDocumentacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreMatricula", x => x.PreMatriculaId);
                });

            migrationBuilder.CreateTable(
                name: "RespuestaCupo",
                columns: table => new
                {
                    RespuestaCupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MensajeRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuracionRespuesta = table.Column<TimeSpan>(type: "time", nullable: false),
                    Prioridad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaCupo", x => x.RespuestaCupoId);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoAcudiente",
                columns: table => new
                {
                    TelefonoAcudienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indicativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcudienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoAcudiente", x => x.TelefonoAcudienteId);
                });

            migrationBuilder.InsertData(
                table: "Acudiente",
                columns: new[] { "AcudienteId", "Apellidos", "CorreoElectronico", "Estado", "EstadoCivil", "FechaNacimiento", "FechaRegistro", "Genero", "Nombres", "NumeroIdentificacion", "Ocupacion", "RelacionConEstudiante" },
                values: new object[,]
                {
                    { new Guid("4b8f80d8-0645-4482-886a-dc966cf5e519"), "López", "ana.lopez@email.com", true, "Divorciada", new DateTime(1990, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5996), "Femenino", "Ana", 54321, "Médica", "Tutor Legal" },
                    { new Guid("54ff4357-8d8a-411d-ab58-42d435476b46"), "Luna", "roberto.luna@email.com", true, "Viudo", new DateTime(1970, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(6028), "Masculino", "Roberto", 10293, "Jubilado", "Abuelo" },
                    { new Guid("56a9c7b4-e512-43eb-a811-f71d14f6c8e6"), "Sánchez", "luis.sanchez@email.com", true, "Casado", new DateTime(1972, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(6009), "Masculino", "Luis", 13579, "Contador", "Padre" },
                    { new Guid("74fa1817-7181-4cd4-940d-3041993a9f4a"), "Martínez", "pedro.martinez@email.com", true, "Casado", new DateTime(1988, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(6000), "Masculino", "Pedro", 98765, "Profesor", "Padre" },
                    { new Guid("9432f2e3-23e6-45cd-9432-5d634647838f"), "Hernández", "andres.hernandez@email.com", true, "Casado", new DateTime(1979, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(6021), "Masculino", "Andrés", 97531, "Arquitecto", "Padrino" },
                    { new Guid("9f60be2a-b88b-4d54-b14f-97cebdcb17cd"), "González", "juan.gonzalez@email.com", true, "Soltero", new DateTime(1975, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5992), "Masculino", "Juan", 67890, "Abogado", "Padre" },
                    { new Guid("bb96f26d-e98b-4f2e-9dd3-63e9720c91f0"), "Rodríguez", "carlos.rodriguez@email.com", true, "Soltero", new DateTime(1985, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(6013), "Masculino", "Carlos", 24680, "Ingeniero Civil", "Tío" },
                    { new Guid("bde66664-41f6-4a16-998e-e5d6f52d37d9"), "Díaz", "sofia.diaz@email.com", true, "Soltera", new DateTime(1987, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(6025), "Femenino", "Sofía", 75319, "Profesora", "Tía" },
                    { new Guid("e2582b22-37c0-47e3-87c5-8dd9d25c7dc6"), "Pérez", "maria.perez@email.com", true, "Casada", new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5986), "Femenino", "María", 12345, "Ingeniera", "Madre" },
                    { new Guid("ff959ea3-0a28-4bb1-a211-96f6672f9ade"), "Gómez", "laura.gomez@email.com", true, "Divorciada", new DateTime(1992, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(6017), "Femenino", "Laura", 86420, "Médica", "Madre" }
                });

            migrationBuilder.InsertData(
                table: "Asistencia",
                columns: new[] { "AsistenciaId", "Asistio", "FechaHoraAsistencia", "NombreAsistente", "Notas", "TipoEvento", "UbicacionEvento" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 10, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), "Juan Pérez", "Asistió puntualmente.", "Conferencia", "Salón A" },
                    { 2, false, new DateTime(2023, 10, 4, 15, 30, 0, 0, DateTimeKind.Unspecified), "María Rodríguez", "No pudo asistir debido a un compromiso previo.", "Reunión", "Sala de juntas" },
                    { 3, true, new DateTime(2023, 10, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "Carlos González", "Participó activamente en el taller.", "Taller", "Aula 101" },
                    { 4, true, new DateTime(2023, 10, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), "Ana López", "Tomó notas detalladas durante la conferencia.", "Conferencia", "Salón B" },
                    { 5, true, new DateTime(2023, 10, 7, 18, 0, 0, 0, DateTimeKind.Unspecified), "Pedro Ramírez", "Participó en la discusión de temas importantes.", "Reunión", "Sala de conferencias" },
                    { 6, true, new DateTime(2023, 10, 8, 11, 45, 0, 0, DateTimeKind.Unspecified), "Laura Martínez", "Hizo preguntas interesantes durante el seminario.", "Seminario", "Auditorio" }
                });

            migrationBuilder.InsertData(
                table: "Aulas",
                columns: new[] { "AulaId", "Capacidad", "EstadoAula", "HorarioDisponibilidad", "NombreNumero", "NotasAdicionales", "RegistrosIncidentesProblemas", "ResponsableAula", "TipoAula", "Ubicacion", "UltimaActualizacion" },
                values: new object[,]
                {
                    { new Guid("93b0fa00-55b5-4739-9970-599b7a224d38"), 10, "Disponible", "Lunes a Domingo, 09:00 AM - 11:00 PM", "Aula 105", "Área de estudio tranquila", "Ninguno", "Bibliotecario", "Sala de Estudio", "Biblioteca", new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b8f1f96-61f3-4d25-b979-ff27c2facfca"), 100, "Disponible", "Disponible previa reserva", "Aula 103", "Equipada con proyector y sistema de sonido", "Ninguno", "Personal de Eventos", "Sala de Conferencias", "Edificio de Eventos", new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b938ca56-e983-4ac7-bf37-6b5a770441fe"), 40, "En Mantenimiento", "No disponible temporalmente", "Aula 104", "Mantenimiento programado", "Reporte de fugas de agua en el techo", "Personal de Mantenimiento", "Salón de Clases", "Edificio Principal", new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c76bf257-0b0f-4d60-91bb-195a5504b8a3"), 30, "Ocupado", "Lunes a Viernes, 10:00 AM - 05:00 PM", "Aula 102", "Equipado con computadoras de última generación", "Reporte de fallo en una computadora", "Profesor Responsable 2", "Laboratorio de Informática", "Edificio de Ciencias", new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb277d02-270e-4780-8733-1d90e570528f"), 50, "Disponible", "Lunes a Viernes, 08:00 AM - 06:00 PM", "Aula 101", "Equipada con proyector", "Ninguno", "Profesor Responsable 1", "Salón de Clases", "Edificio Principal", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CandidatoEstudiantes",
                columns: new[] { "CandidatoEstudianteId", "Apellido", "FechaNacimiento", "Nombre", "TipoPersona" },
                values: new object[,]
                {
                    { new Guid("0836ac53-b431-407f-a370-8e68cf67b629"), "Martínez", new DateTime(1993, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", "Estudiante" },
                    { new Guid("49409752-9e3b-429a-b0c0-fb70c6d49197"), "Castro", new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "Estudiante" },
                    { new Guid("4cb2eb42-eac8-446d-ac79-6df5cbc1843e"), "Gómez", new DateTime(1996, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabel", "Estudiante" },
                    { new Guid("7055b6ac-7ec5-4c5c-aadf-9eb84b13c505"), "Hernández", new DateTime(1994, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofía", "Estudiante" },
                    { new Guid("9975a76b-cb45-48e7-b4f2-dd9e5fe2267b"), "Fernández", new DateTime(1989, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto", "Estudiante" },
                    { new Guid("b0d1c69b-fe84-45bd-87e4-d1a2a34bfb42"), "Ramírez", new DateTime(1998, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "Estudiante" },
                    { new Guid("c46760ba-ec7e-4912-850d-d5cfe4eea0b4"), "Díaz", new DateTime(1991, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Francisco", "Estudiante" },
                    { new Guid("f39fc767-56f9-417a-a746-371e3b69d9ea"), "López", new DateTime(2000, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Estudiante" },
                    { new Guid("f57d3215-cc4f-4fe0-bd0a-0b344d76d254"), "Acuña", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Axl", "Estudiante" },
                    { new Guid("f888eafb-169c-45db-882f-976033143d8e"), "Sánchez", new DateTime(1987, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", "Estudiante" }
                });

            migrationBuilder.InsertData(
                table: "Cupo",
                columns: new[] { "CupoId", "CantidadDisponible", "Descripcion", "Duracion", "Estado", "FechaFin", "FechaInicio", "Ubicacion" },
                values: new object[,]
                {
                    { new Guid("3c6f9b30-31f8-40a7-96cb-2ff6910dc0f8"), 5, "Cupo para el taller de programación", new TimeSpan(0, 3, 0, 0, 0), true, new DateTime(2024, 3, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7081), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7080), "Aula 101" },
                    { new Guid("94c253d8-be34-4937-ba13-93f0400356e4"), 20, "Cupo para el seminario de marketing", new TimeSpan(0, 4, 0, 0, 0), true, new DateTime(2024, 4, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7086), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7085), "Aula 102" },
                    { new Guid("cdca8211-078b-4bcc-a580-bc9d20562830"), 30, "Cupo para el evento de networking", new TimeSpan(0, 1, 0, 0, 0), true, new DateTime(2024, 6, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7096), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7095), "Aula 104" },
                    { new Guid("d4bad599-4572-40f7-b9b4-958811b049ce"), 15, "Cupo para el curso de diseño gráfico", new TimeSpan(0, 2, 0, 0, 0), true, new DateTime(2024, 5, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7091), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7090), "Aula 103" },
                    { new Guid("e76cb355-4e59-4152-9ece-cfec11182782"), 10, "Cupo para el evento principal", new TimeSpan(0, 2, 0, 0, 0), true, new DateTime(2024, 2, 29, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7057), new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7056), "Salón principal" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "AulasAsignadas", "Codigo", "Curso", "DepartamentoAcademico", "Descripcion", "FechaLimiteInscripcion", "MetodosEnsenanza", "Nivel", "ProfesorAsignado" },
                values: new object[,]
                {
                    { new Guid("2aaf4cb4-ea06-408b-a359-c5d54c403437"), "Chemistry Lab 201", "CHEM401", 401, "Chemistry Department", "Organic Chemistry", new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lectures, laboratory experiments", "Second Semester", "Professor 4" },
                    { new Guid("59d2e468-b2e8-4f29-a60c-6b28eee1e7c3"), "Math Classroom 301", "MATH301", 301, "Mathematics Department", "Advanced Calculus", new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lectures, problem sets, exams", "Third Semester", "Professor 3" },
                    { new Guid("8e5df352-bc5c-4488-b284-d7d9f153e382"), "Aula 101, Aula 102", "CS101", 101, "Ciencias de la Computación", "Introducción a la Programación", new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clases magistrales, laboratorios prácticos", "Primer Semestre", "Profesor 1" },
                    { new Guid("e79e732f-2c9b-4043-b62d-e82adc62b58f"), "History Classroom 101", "HIST501", 501, "History Department", "Introduction to History", new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lectures, discussions, research papers", "First Semester", "Professor 5" },
                    { new Guid("ebe9d013-05aa-4313-80ea-05df716bec7f"), "Classroom 201, Classroom 202", "ENG201", 201, "English Department", "Advanced English Composition", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lectures, writing assignments, group discussions", "Second Semester", "Professor 2" }
                });

            migrationBuilder.InsertData(
                table: "DireccionAcudiente",
                columns: new[] { "DireccionAcudienteId", "Calle", "CiudadLocalidad", "CodigoPostal", "ColoniaBarrio", "EstadoProvincia", "Pais" },
                values: new object[,]
                {
                    { new Guid("17e0d49b-22a7-4839-9533-e658634afbe9"), "Avenida 68", "Bogotá", "110841", "Kennedy", "Bogotá D.C.", "Colombia" },
                    { new Guid("32825096-9b47-482c-a080-f02d5666b4e1"), "Calle 80", "Bogotá", "110841", "Engativá", "Bogotá D.C.", "Colombia" },
                    { new Guid("42493fc5-9815-4fe3-a9f9-f96bbb8d4aed"), "Carrera 7", "Bogotá", "110171", "Usaquén", "Bogotá D.C.", "Colombia" },
                    { new Guid("592a9608-d1e5-49e7-a388-2df1bb036b15"), "Avenida Boyacá", "Bogotá", "110511", "Fontibón", "Bogotá D.C.", "Colombia" },
                    { new Guid("5cc80e17-3f17-4d41-ae6f-873652fdbd15"), "Carrera 10", "Bogotá", "110321", "La Candelaria", "Bogotá D.C.", "Colombia" },
                    { new Guid("c8413278-7eee-43c6-80d5-d08459f0d999"), "Calle 72", "Bogotá", "110231", "Chapinero", "Bogotá D.C.", "Colombia" },
                    { new Guid("ca17cb2e-cbf9-40d3-8f2d-712973667c76"), "Calle 72", "Bogotá", "110231", "Chapinero", "Bogotá D.C.", "Colombia" }
                });

            migrationBuilder.InsertData(
                table: "Estadisticas",
                columns: new[] { "EstadisticaId", "AñoEscolar", "CantidadExamenes", "FechaRegistro", "Materia", "NotaMaxima", "NotaMinima", "NotaPromedio", "PeriodoEscolar" },
                values: new object[,]
                {
                    { 1, 2023, 5, new DateTime(2024, 1, 30, 9, 34, 8, 92, DateTimeKind.Local).AddTicks(398), "Matemáticas", 9.0m, 7.5m, 8.5m, "Primer Trimestre" },
                    { 2, 2023, 4, new DateTime(2024, 1, 30, 9, 34, 8, 92, DateTimeKind.Local).AddTicks(403), "Ciencias", 8.5m, 6.5m, 7.8m, "Segundo Trimestre" },
                    { 3, 2023, 3, new DateTime(2024, 1, 30, 9, 34, 8, 92, DateTimeKind.Local).AddTicks(407), "Historia", 9.5m, 8.5m, 9.2m, "Tercer Trimestre" },
                    { 4, 2023, 5, new DateTime(2024, 1, 30, 9, 34, 8, 92, DateTimeKind.Local).AddTicks(410), "Lenguaje", 8.0m, 6.0m, 7.2m, "Primer Semestre" },
                    { 5, 2023, 2, new DateTime(2024, 1, 30, 9, 34, 8, 92, DateTimeKind.Local).AddTicks(413), "Arte", 9.0m, 8.0m, 8.7m, "Segundo Semestre" },
                    { 6, 2023, 3, new DateTime(2024, 1, 30, 9, 34, 8, 92, DateTimeKind.Local).AddTicks(416), "Educación Física", 10.0m, 9.0m, 9.5m, "Trimestre Extra" }
                });

            migrationBuilder.InsertData(
                table: "EstudianteDocumentos",
                columns: new[] { "EstudianteDocumentosId", "CandidatoEstudianteId", "Estado", "FechaActualizacion", "NombreDocumento", "NumeroDocumento", "Observaciones", "Tamaño", "TipoDocumento", "Ubicacion" },
                values: new object[,]
                {
                    { new Guid("10a5e754-1570-4be0-8650-2c53d7cfb4d3"), new Guid("b3b5a5a7-5b82-4f76-98c1-654589db8f61"), true, new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5656), "Fotografía del Estudiante", 1111111, "Foto de perfil", 1024, "Identificación", "ruta/al/documento10" },
                    { new Guid("2d54a999-187f-4a8c-99db-d17841e7938c"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), true, new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5603), "Diploma", 987654, "Logros académicos", 2048, "Educativo", "ruta/al/documento2" },
                    { new Guid("3e68515e-3a47-4a62-a8c7-9f12242d020e"), new Guid("4f3657e5-5824-47b8-b4cd-6f49a3f4dbf1"), false, new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5623), "Certificado de Graduación", 123456, "Graduación universitaria", 1536, "Educativo", "ruta/al/documento3" },
                    { new Guid("4a303cce-8c0e-4ae7-89c1-067d0b7741b6"), new Guid("3e68515e-3a47-4a62-a8c7-9f12242d020e"), true, new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5628), "Certificado de Matrícula", 789012, "Matrícula escolar", 8192, "Educativo", "ruta/al/documento4" },
                    { new Guid("5f78d0e1-579e-4dfc-82a1-92010b4191d3"), new Guid("31eb541a-9419-4eac-bf1b-0289a6c6f6f0"), true, new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5632), "Cédula de Identidad", 555555, "Documento oficial", 4096, "Identificación", "ruta/al/documento5" },
                    { new Guid("6a30c846-4b9d-4cf5-bb17-051a3e9d1b72"), new Guid("c9d4c053-49b6-410c-bc78-2d54a999187f"), true, null, "Certificado de Nacimiento", 61464465, "Ninguna", 1024, "Identificación", "ruta/al/documento1" },
                    { new Guid("7e15d9a4-98cb-4d14-9a35-862f8c202725"), new Guid("bb9b0679-4f04-4ac4-9ddc-5c3e50e81298"), true, new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5642), "Boleta de Calificaciones", 9876543, "Registro académico", 5120, "Educativo", "ruta/al/documento7" },
                    { new Guid("8f4a67c2-fd5e-4316-8c50-7249f159d0f1"), new Guid("a6509bea-688e-43b5-a870-6ee461ccf601"), true, new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5646), "Pasaporte", 1234567, "Documento de viaje", 4096, "Identificación", "ruta/al/documento8" },
                    { new Guid("9b9d6d8f-72f0-4f0a-8e18-1e75b0182e3f"), new Guid("db9fcac5-8654-45c3-87c7-8b5e13e9e6c2"), true, new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5651), "Certificado Médico", 543210, "Informe médico", 2048, "Salud", "ruta/al/documento9" },
                    { new Guid("f38f6b1a-86e9-4d9d-8a7a-62f17e6f1ba2"), new Guid("7f255218-f8e0-45a9-9807-12e1bcfd438c"), true, new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(5637), "Carné de Estudiante", 7890123, "Carné escolar", 3072, "Identificación", "ruta/al/documento6" }
                });

            migrationBuilder.InsertData(
                table: "Horarios",
                columns: new[] { "HorarioId", "DiaSemana", "DuracionClaseMinutos", "EstadoHorario", "FechaFinClases", "FechaInicioClases", "GrupoSeccion", "HoraFin", "HoraInicio", "NotificacionCambioHorario", "PeriodoAcademico", "ProfesorAsistente", "SalaAula" },
                values: new object[,]
                {
                    { new Guid("36f151bd-cc88-42fc-b7a2-71d3e75b6579"), "Viernes", 120, "Activo", new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grupo E", new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "No", "Semestre de Primavera", "Profesor Asistente 5", "Aula 102" },
                    { new Guid("3e2fa338-b3e8-4683-96d5-5470da889b85"), "Lunes", 120, "Activo", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grupo A", new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), "No", "Semestre de Otoño", "Profesor Asistente 1", "Aula 101" },
                    { new Guid("45d4cc9b-b617-4b9b-98fe-b45945d8c461"), "Martes", 120, "Activo", new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grupo B", new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0), "Sí", "Semestre de Primavera", "Profesor Asistente 2", "Aula 203" },
                    { new Guid("7eb27728-e584-46b4-adc1-9a3eace613f4"), "Jueves", 120, "Activo", new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grupo D", new TimeSpan(0, 18, 30, 0, 0), new TimeSpan(0, 16, 30, 0, 0), "Sí", "Semestre de Invierno", "Profesor Asistente 4", "Aula 401" },
                    { new Guid("d4b084ae-ac9e-424d-a5d4-20396c474862"), "Miércoles", 120, "Activo", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grupo C", new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0), "No", "Semestre de Verano", "Profesor Asistente 3", "Aula 305" }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "MateriaId", "DepartamentoAcademico", "Descripcion", "Estado", "GrupoSeccionMateria", "MetodosEnsenanza", "ModalidadEnsenanza", "Nivel", "Nombre", "NotasAdicionales", "ProfesorAsignado" },
                values: new object[,]
                {
                    { new Guid("04e52085-89d3-4053-a6c2-dee9fbf5cdee"), "Departamento de Matemáticas", "Curso de Matemáticas Avanzadas", "En progreso", "Grupo A", "Clases teóricas y prácticas", "Presencial", "Avanzado", "Matemáticas", "Se requiere calculadora científica.", "Profesor Matemático" },
                    { new Guid("256565eb-9dd8-483b-bb99-362a544ed06e"), "Departamento de Literatura", "Curso de Literatura Universal", "Inscripciones abiertas", "Grupo D", "Lecturas y discusiones literarias", "Presencial", "Intermedio", "Literatura", "Apto para amantes de la lectura.", "Profesor Literario" },
                    { new Guid("26ccc9b3-c319-4e16-b6ad-28393ba5372e"), "Departamento de Física", "Curso de Física Avanzada", "Completo", "Grupo E", "Experimentos y clases teóricas", "Presencial", "Avanzado", "Física", "Requiere conocimientos previos de física.", "Profesor de Física" },
                    { new Guid("67560243-6625-47b2-979b-2ceb87605fcc"), "Departamento de Informática", "Curso de Ciencias de la Computación", "En progreso", "Grupo C", "Clases virtuales y proyectos prácticos", "En línea", "Avanzado", "Ciencias de la Computación", "Requiere acceso a una computadora.", "Profesor de Informática" },
                    { new Guid("8abd2723-8ca8-4fdc-8aed-767c74bcd98e"), "Departamento de Arte", "Curso de Arte Contemporáneo", "Inscripciones abiertas", "Grupo G", "Prácticas artísticas y exposiciones", "Presencial", "Intermedio", "Arte", "No se requiere experiencia previa en arte.", "Profesor de Arte" },
                    { new Guid("b258699b-db45-44be-aa86-7b9e457b0bfc"), "Departamento de Historia", "Curso de Historia Mundial", "Inscripciones abiertas", "Grupo B", "Conferencias y debates", "Presencial", "Intermedio", "Historia", "Recomendado para estudiantes de Historia.", "Profesor Historiador" },
                    { new Guid("bd769b1b-b3c8-478d-8c68-622055fd63cf"), "Departamento de Economía", "Curso de Economía Moderna", "En progreso", "Grupo F", "Clases virtuales y análisis económico", "En línea", "Intermedio", "Economía", "Abordaremos temas financieros actuales.", "Profesor Economista" }
                });

            migrationBuilder.InsertData(
                table: "Matricula",
                columns: new[] { "MatriculaId", "CategoriaMatricula", "Comentarios", "EstadoMatricula", "FechaMatricula", "InformacionPlanEstudios", "PeriodoAcademico", "RegistroCambios", "TipoMatricula" },
                values: new object[,]
                {
                    { new Guid("030f8ddd-63b4-4e86-9872-48213adeb5a5"), "Estudiante de Tiempo Completo", "Comentario sobre la matrícula 1", "Activa", new DateTime(2024, 1, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(8124), "Plan de estudios 2023", 2024, "Registro de cambios 1", "Matrícula Regular" },
                    { new Guid("0a5f6a6a-052a-4885-ba55-1be112c1be0d"), "Estudiante Internacional", "Comentario sobre la matrícula 3", "Cancelada", new DateTime(2024, 3, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(8136), "Plan de estudios 2023", 2024, "Registro de cambios 3", "Matrícula Regular" },
                    { new Guid("2b0e549b-6eb8-47ed-8444-7a9d8e8d3871"), "Estudiante de Tiempo Completo", "Comentario sobre la matrícula 4", "Activa", new DateTime(2024, 4, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(8141), "Plan de estudios 2023", 2024, "Registro de cambios 4", "Matrícula Regular" },
                    { new Guid("4cf41d02-83dd-48cd-a8c1-f9ea4f65233f"), "Estudiante de Tiempo Completo", "Comentario sobre la matrícula 5", "Activa", new DateTime(2024, 5, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(8146), "Plan de estudios 2023", 2024, "Registro de cambios 5", "Matrícula Regular" },
                    { new Guid("53497f2b-6047-4422-a072-c4bb55071cd1"), "Estudiante de Tiempo Parcial", "Comentario sobre la matrícula 2", "Pendiente", new DateTime(2024, 2, 29, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(8131), "Plan de estudios 2023", 2024, "Registro de cambios 2", "Matrícula Parcial" }
                });

            migrationBuilder.InsertData(
                table: "PreMatricula",
                columns: new[] { "PreMatriculaId", "EstadoPreMatricula", "GradoONivel", "Observaciones", "RequisitosDocumentacion", "Turno" },
                values: new object[,]
                {
                    { new Guid("4fb8157e-2554-498f-a34f-ae5065a06991"), "Activa", "Segundo de Primaria", "Estudiante con discapacidad visual.", "SiCumplio", "Mañana" },
                    { new Guid("7b8f1193-3097-44d3-8103-06450d90110a"), "Activa", "Cuarto de Secundaria", "Estudiante con beca deportiva.", "SiCumplio", "Tarde" },
                    { new Guid("b89064ad-d771-455d-af95-2f992b58e2c6"), "Pendiente", "Tercero de Primaria", "Estudiante extranjero.", "SiCumplio", "Mañana" },
                    { new Guid("e2003266-ef8f-4a96-a780-f66c448480f3"), "Pendiente", "Quinto de Primaria", "Estudiante con requerimientos especiales.", "NoCumplio", "Mañana" },
                    { new Guid("eb5c2b07-a105-4d70-b327-48bae638caa0"), "Activa", "Séptimo de Secundaria", "Estudiante de transferencia.", "SiCumplio", "Tarde" },
                    { new Guid("ffc62a15-35be-41f4-b98a-056d1bdd732f"), "Pendiente", "Octavo de Secundaria", "Estudiante sin observaciones adicionales.", "Si cumplio", "Tarde" }
                });

            migrationBuilder.InsertData(
                table: "RespuestaCupo",
                columns: new[] { "RespuestaCupoId", "DuracionRespuesta", "EstadoRespuesta", "FechaRespuesta", "FechaVencimiento", "MensajeRespuesta", "Prioridad", "TipoRespuesta", "UsuarioRespuesta" },
                values: new object[,]
                {
                    { new Guid("249f90ab-b016-4fc8-b44f-647586233694"), new TimeSpan(45, 0, 0, 0, 0), "Rechazada", new DateTime(2024, 2, 4, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7443), new DateTime(2024, 6, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7444), "Respuesta 5", "Media", "Rechazo", "Usuario5" },
                    { new Guid("56065618-28f6-4009-9194-53ad92d0566c"), new TimeSpan(45, 0, 0, 0, 0), "Rechazada", new DateTime(2024, 2, 6, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7453), new DateTime(2024, 8, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7454), "Respuesta 7", "Media", "Rechazo", "Usuario7" },
                    { new Guid("5dff8d92-73c7-42cb-9af6-b6d51f3bcc1b"), new TimeSpan(30, 0, 0, 0, 0), "Aceptada", new DateTime(2024, 1, 31, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7410), new DateTime(2024, 2, 29, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7416), "Respuesta 1", "Alta", "Aceptación", "Usuario1" },
                    { new Guid("72d4463e-11f5-4d45-9390-9865fc078028"), new TimeSpan(30, 0, 0, 0, 0), "Aceptada", new DateTime(2024, 2, 8, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7462), new DateTime(2024, 10, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7463), "Respuesta 9", "Alta", "Aceptación", "Usuario9" },
                    { new Guid("888bade6-2edc-4379-9f7d-0b721ff43b36"), new TimeSpan(45, 0, 0, 0, 0), "Rechazada", new DateTime(2024, 2, 1, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7425), new DateTime(2024, 3, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7427), "Respuesta 2", "Media", "Rechazo", "Usuario2" },
                    { new Guid("da73ae1c-8b9f-41d8-8d64-0f22f96aee9c"), new TimeSpan(60, 0, 0, 0, 0), "Pendiente", new DateTime(2024, 2, 2, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7431), new DateTime(2024, 4, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7432), "Respuesta 3", "Baja", "Pendiente", "Usuario3" },
                    { new Guid("decc16ff-aec2-4f06-ab6e-75d2c38abab6"), new TimeSpan(30, 0, 0, 0, 0), "Aceptada", new DateTime(2024, 2, 5, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7448), new DateTime(2024, 7, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7449), "Respuesta 6", "Alta", "Aceptación", "Usuario6" },
                    { new Guid("ecf23155-ecd9-4e58-8670-39eeaf42016c"), new TimeSpan(30, 0, 0, 0, 0), "Aceptada", new DateTime(2024, 2, 3, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7436), new DateTime(2024, 5, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7437), "Respuesta 4", "Alta", "Aceptación", "Usuario4" },
                    { new Guid("f5dc5219-e91e-4c2a-bf8c-9a9576857853"), new TimeSpan(60, 0, 0, 0, 0), "Pendiente", new DateTime(2024, 2, 7, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7457), new DateTime(2024, 9, 30, 9, 34, 8, 91, DateTimeKind.Local).AddTicks(7459), "Respuesta 8", "Baja", "Pendiente", "Usuario8" }
                });

            migrationBuilder.InsertData(
                table: "TelefonoAcudiente",
                columns: new[] { "TelefonoAcudienteId", "AcudienteId", "Indicativo", "Numero", "Tipo" },
                values: new object[,]
                {
                    { new Guid("178c9816-b86a-46b3-a7da-60473146ef06"), 2, "+1", -1889, "Móvil" },
                    { new Guid("2557cf66-e9af-4afb-bc08-06685d3971d0"), 4, "+1", -4333, "Móvil" },
                    { new Guid("80cea964-edbd-482d-9b26-fcf9df86873f"), 4, "+1", -5753, "Móvil" },
                    { new Guid("81afc35b-48cc-4545-a9d3-096684f4df7a"), 1, "+1", -4135, "Móvil" },
                    { new Guid("8a2c43f6-6b64-42e2-9c71-3ece19bf905d"), 3, "+1", -3111, "Fijo" },
                    { new Guid("999be28d-0d74-49e4-ae35-3b16e39b3907"), 2, "+1", -6975, "Móvil" },
                    { new Guid("9aa54acd-deb5-4b34-8e0b-1c9ab2915784"), 5, "+1", 911, "Emergencia" },
                    { new Guid("b511bd7d-a1b1-4c9f-939d-21586f433b9e"), 5, "+1", -5555, "Emergencia" },
                    { new Guid("c7445617-62ac-4629-bda4-e1149e232f7d"), 3, "+1", -5357, "Fijo" },
                    { new Guid("cc037f26-aeff-4d6d-80e5-c46188cd38f8"), 1, "+1", -667, "Móvil" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acudiente");

            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "CandidatoEstudiantes");

            migrationBuilder.DropTable(
                name: "Cupo");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "DireccionAcudiente");

            migrationBuilder.DropTable(
                name: "Estadisticas");

            migrationBuilder.DropTable(
                name: "EstudianteDocumentos");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "PreMatricula");

            migrationBuilder.DropTable(
                name: "RespuestaCupo");

            migrationBuilder.DropTable(
                name: "TelefonoAcudiente");
        }
    }
}
