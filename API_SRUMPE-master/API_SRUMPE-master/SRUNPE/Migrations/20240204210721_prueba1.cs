using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SRUNPE.Migrations
{
    /// <inheritdoc />
    public partial class prueba1 : Migration
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
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("0ff17d5d-6183-4d58-bf1e-aeaea6a7aa62"), "López", "ana.lopez@email.com", true, "Divorciada", new DateTime(1990, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6334), "Femenino", "Ana", 54321, "Médica", "Tutor Legal" },
                    { new Guid("285915f3-78f9-44c0-85e4-dccc0f2f6e6a"), "Luna", "roberto.luna@email.com", true, "Viudo", new DateTime(1970, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6353), "Masculino", "Roberto", 10293, "Jubilado", "Abuelo" },
                    { new Guid("2998699f-7e97-4804-8a2a-a2378c56f6fe"), "Sánchez", "luis.sanchez@email.com", true, "Casado", new DateTime(1972, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6342), "Masculino", "Luis", 13579, "Contador", "Padre" },
                    { new Guid("54600650-7007-405d-8f82-8c4d584b3af5"), "Gómez", "laura.gomez@email.com", true, "Divorciada", new DateTime(1992, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6346), "Femenino", "Laura", 86420, "Médica", "Madre" },
                    { new Guid("55f9121f-6262-40ab-b33c-9feec7cf9b75"), "Rodríguez", "carlos.rodriguez@email.com", true, "Soltero", new DateTime(1985, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6344), "Masculino", "Carlos", 24680, "Ingeniero Civil", "Tío" },
                    { new Guid("5c7b53c8-4032-4b6f-b55a-0f39be78ef04"), "Díaz", "sofia.diaz@email.com", true, "Soltera", new DateTime(1987, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6351), "Femenino", "Sofía", 75319, "Profesora", "Tía" },
                    { new Guid("6624b394-37c3-44b0-bd71-ce73f9c9b51b"), "Pérez", "maria.perez@email.com", true, "Casada", new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6328), "Femenino", "María", 12345, "Ingeniera", "Madre" },
                    { new Guid("71443ae2-02ea-434c-af26-67c86d5769ec"), "Hernández", "andres.hernandez@email.com", true, "Casado", new DateTime(1979, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6349), "Masculino", "Andrés", 97531, "Arquitecto", "Padrino" },
                    { new Guid("96303924-3699-4056-9104-1df5567488df"), "González", "juan.gonzalez@email.com", true, "Soltero", new DateTime(1975, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6331), "Masculino", "Juan", 67890, "Abogado", "Padre" },
                    { new Guid("af1053d8-94d3-49b1-bb4a-58a17d74fb4e"), "Martínez", "pedro.martinez@email.com", true, "Casado", new DateTime(1988, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6339), "Masculino", "Pedro", 98765, "Profesor", "Padre" }
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
                    { new Guid("01ad2377-7fa3-4b14-9ae7-9540bdd52cee"), 10, "Disponible", "Lunes a Domingo, 09:00 AM - 11:00 PM", "Aula 105", "Área de estudio tranquila", "Ninguno", "Bibliotecario", "Sala de Estudio", "Biblioteca", new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("268625d1-459f-4a92-bbb8-907a76d8f8c6"), 40, "En Mantenimiento", "No disponible temporalmente", "Aula 104", "Mantenimiento programado", "Reporte de fugas de agua en el techo", "Personal de Mantenimiento", "Salón de Clases", "Edificio Principal", new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70520c79-41d9-4655-a137-6cdf1c2bf646"), 50, "Disponible", "Lunes a Viernes, 08:00 AM - 06:00 PM", "Aula 101", "Equipada con proyector", "Ninguno", "Profesor Responsable 1", "Salón de Clases", "Edificio Principal", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dadbeac7-9882-4740-8158-a0e8a4f51bf5"), 30, "Ocupado", "Lunes a Viernes, 10:00 AM - 05:00 PM", "Aula 102", "Equipado con computadoras de última generación", "Reporte de fallo en una computadora", "Profesor Responsable 2", "Laboratorio de Informática", "Edificio de Ciencias", new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fd9033db-604b-4c0f-bcc2-41c04bce4641"), 100, "Disponible", "Disponible previa reserva", "Aula 103", "Equipada con proyector y sistema de sonido", "Ninguno", "Personal de Eventos", "Sala de Conferencias", "Edificio de Eventos", new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CandidatoEstudiantes",
                columns: new[] { "CandidatoEstudianteId", "Apellido", "Direccion", "FechaNacimiento", "Nombre", "Telefono", "TipoPersona" },
                values: new object[,]
                {
                    { new Guid("08314d06-16cc-4c5f-992b-20b1342a1268"), "Hernández", "calle 1", new DateTime(1994, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofía", 123456, "Estudiante" },
                    { new Guid("1b951756-e8e7-495c-94be-324bb9f5144d"), "López", "calle 7", new DateTime(2000, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", 123456, "Estudiante" },
                    { new Guid("327fb1ce-2908-48b3-8bf6-445d9d730def"), "Castro", "calle 9", new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", 123456, "Estudiante" },
                    { new Guid("3ccab877-a601-4a15-90f5-36985c897ae1"), "Fernández", "calle 4", new DateTime(1989, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto", 123456, "Estudiante" },
                    { new Guid("68469754-6f4f-4f66-81bd-96cf39ef664a"), "Martínez", "calle 5", new DateTime(1993, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", 123456, "Estudiante" },
                    { new Guid("74b1e102-80f2-43c4-a35a-e772aa7c9256"), "Acuña", "calle 10", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Axl", 123456, "Estudiante" },
                    { new Guid("7ee9663b-de19-4825-96f3-d1b3da730dd1"), "Díaz", "calle 2", new DateTime(1991, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Francisco", 123456, "Estudiante" },
                    { new Guid("cb9f6dc3-1f86-49dd-be20-250be8344931"), "Ramírez", "calle 6", new DateTime(1998, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", 123456, "Estudiante" },
                    { new Guid("dba06ff8-366b-409a-b4a7-47fb78aa2e74"), "Sánchez", "calle 8", new DateTime(1987, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", 123456, "Estudiante" },
                    { new Guid("f743d562-e940-4647-9030-8649288a8671"), "Gómez", "calle 3", new DateTime(1996, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabel", 123456, "Estudiante" }
                });

            migrationBuilder.InsertData(
                table: "Cupo",
                columns: new[] { "CupoId", "CantidadDisponible", "Descripcion", "Duracion", "Estado", "FechaFin", "FechaInicio", "Ubicacion" },
                values: new object[,]
                {
                    { new Guid("1b843e4e-7d3d-4545-b03e-a7019c0d03a5"), 30, "Cupo para el evento de networking", new TimeSpan(0, 1, 0, 0, 0), true, new DateTime(2024, 7, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7009), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7008), "Aula 104" },
                    { new Guid("6bde23dc-75aa-4d1f-bd4a-af0b4f8418d5"), 10, "Cupo para el evento principal", new TimeSpan(0, 2, 0, 0, 0), true, new DateTime(2024, 3, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6982), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6981), "Salón principal" },
                    { new Guid("739b37a1-680c-465e-8f04-e79cabd209c8"), 5, "Cupo para el taller de programación", new TimeSpan(0, 3, 0, 0, 0), true, new DateTime(2024, 4, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7000), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7000), "Aula 101" },
                    { new Guid("8ac36878-ffe4-4d1a-ac7a-a9a545c11683"), 20, "Cupo para el seminario de marketing", new TimeSpan(0, 4, 0, 0, 0), true, new DateTime(2024, 5, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7003), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7003), "Aula 102" },
                    { new Guid("e284aada-d51c-4eda-afe5-328ac4319581"), 15, "Cupo para el curso de diseño gráfico", new TimeSpan(0, 2, 0, 0, 0), true, new DateTime(2024, 6, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7006), new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7006), "Aula 103" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "AulasAsignadas", "Codigo", "Curso", "DepartamentoAcademico", "Descripcion", "FechaLimiteInscripcion", "MetodosEnsenanza", "Nivel", "ProfesorAsignado" },
                values: new object[,]
                {
                    { new Guid("55d9da66-dce5-4623-b65c-f847bca3c5ed"), "Aula 101, Aula 102", "CS101", 101, "Ciencias de la Computación", "Introducción a la Programación", new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clases magistrales, laboratorios prácticos", "Primer Semestre", "Profesor 1" },
                    { new Guid("879a965e-f936-49e2-8c38-f963ffd4525c"), "Classroom 201, Classroom 202", "ENG201", 201, "English Department", "Advanced English Composition", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lectures, writing assignments, group discussions", "Second Semester", "Professor 2" },
                    { new Guid("97fed96b-01eb-4b77-8b08-b5640d3097b1"), "History Classroom 101", "HIST501", 501, "History Department", "Introduction to History", new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lectures, discussions, research papers", "First Semester", "Professor 5" },
                    { new Guid("afe1908f-d23e-4de6-9276-d96fb740f829"), "Math Classroom 301", "MATH301", 301, "Mathematics Department", "Advanced Calculus", new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lectures, problem sets, exams", "Third Semester", "Professor 3" },
                    { new Guid("d2b19a24-1de8-4c82-8917-4e612e99c201"), "Chemistry Lab 201", "CHEM401", 401, "Chemistry Department", "Organic Chemistry", new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lectures, laboratory experiments", "Second Semester", "Professor 4" }
                });

            migrationBuilder.InsertData(
                table: "DireccionAcudiente",
                columns: new[] { "DireccionAcudienteId", "Calle", "CiudadLocalidad", "CodigoPostal", "ColoniaBarrio", "EstadoProvincia", "Pais" },
                values: new object[,]
                {
                    { new Guid("0de111a7-810f-4b75-b957-643cbe3d7b74"), "Calle 72", "Bogotá", "110231", "Chapinero", "Bogotá D.C.", "Colombia" },
                    { new Guid("28f1ce21-eb12-40bc-bca5-613a3f000a14"), "Calle 72", "Bogotá", "110231", "Chapinero", "Bogotá D.C.", "Colombia" },
                    { new Guid("48116869-2292-499f-9e7d-60ec2ea28d65"), "Avenida 68", "Bogotá", "110841", "Kennedy", "Bogotá D.C.", "Colombia" },
                    { new Guid("5e4f4401-731e-4766-8776-5f1a2a423d98"), "Carrera 10", "Bogotá", "110321", "La Candelaria", "Bogotá D.C.", "Colombia" },
                    { new Guid("84351207-d6e1-46ab-aa22-7f881163d464"), "Avenida Boyacá", "Bogotá", "110511", "Fontibón", "Bogotá D.C.", "Colombia" },
                    { new Guid("a657e50a-2d15-407d-8634-5710908dbfb3"), "Calle 80", "Bogotá", "110841", "Engativá", "Bogotá D.C.", "Colombia" },
                    { new Guid("f6b8c5f8-3951-442a-ac5f-2605fa72cf0b"), "Carrera 7", "Bogotá", "110171", "Usaquén", "Bogotá D.C.", "Colombia" }
                });

            migrationBuilder.InsertData(
                table: "Estadisticas",
                columns: new[] { "EstadisticaId", "AñoEscolar", "CantidadExamenes", "FechaRegistro", "Materia", "NotaMaxima", "NotaMinima", "NotaPromedio", "PeriodoEscolar" },
                values: new object[,]
                {
                    { 1, 2023, 5, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(9086), "Matemáticas", 9.0m, 7.5m, 8.5m, "Primer Trimestre" },
                    { 2, 2023, 4, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(9091), "Ciencias", 8.5m, 6.5m, 7.8m, "Segundo Trimestre" },
                    { 3, 2023, 3, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(9095), "Historia", 9.5m, 8.5m, 9.2m, "Tercer Trimestre" },
                    { 4, 2023, 5, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(9097), "Lenguaje", 8.0m, 6.0m, 7.2m, "Primer Semestre" },
                    { 5, 2023, 2, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(9100), "Arte", 9.0m, 8.0m, 8.7m, "Segundo Semestre" },
                    { 6, 2023, 3, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(9103), "Educación Física", 10.0m, 9.0m, 9.5m, "Trimestre Extra" }
                });

            migrationBuilder.InsertData(
                table: "EstudianteDocumentos",
                columns: new[] { "EstudianteDocumentosId", "CandidatoEstudianteId", "Estado", "FechaActualizacion", "NombreDocumento", "NumeroDocumento", "Observaciones", "Tamaño", "TipoDocumento", "Ubicacion" },
                values: new object[,]
                {
                    { new Guid("10a5e754-1570-4be0-8650-2c53d7cfb4d3"), new Guid("b3b5a5a7-5b82-4f76-98c1-654589db8f61"), true, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6093), "Fotografía del Estudiante", 1111111, "Foto de perfil", 1024, "Identificación", "ruta/al/documento10" },
                    { new Guid("2d54a999-187f-4a8c-99db-d17841e7938c"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), true, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6055), "Diploma", 987654, "Logros académicos", 2048, "Educativo", "ruta/al/documento2" },
                    { new Guid("3e68515e-3a47-4a62-a8c7-9f12242d020e"), new Guid("4f3657e5-5824-47b8-b4cd-6f49a3f4dbf1"), false, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6072), "Certificado de Graduación", 123456, "Graduación universitaria", 1536, "Educativo", "ruta/al/documento3" },
                    { new Guid("4a303cce-8c0e-4ae7-89c1-067d0b7741b6"), new Guid("3e68515e-3a47-4a62-a8c7-9f12242d020e"), true, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6075), "Certificado de Matrícula", 789012, "Matrícula escolar", 8192, "Educativo", "ruta/al/documento4" },
                    { new Guid("5f78d0e1-579e-4dfc-82a1-92010b4191d3"), new Guid("31eb541a-9419-4eac-bf1b-0289a6c6f6f0"), true, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6079), "Cédula de Identidad", 555555, "Documento oficial", 4096, "Identificación", "ruta/al/documento5" },
                    { new Guid("6a30c846-4b9d-4cf5-bb17-051a3e9d1b72"), new Guid("c9d4c053-49b6-410c-bc78-2d54a999187f"), true, null, "Certificado de Nacimiento", 61464465, "Ninguna", 1024, "Identificación", "ruta/al/documento1" },
                    { new Guid("7e15d9a4-98cb-4d14-9a35-862f8c202725"), new Guid("bb9b0679-4f04-4ac4-9ddc-5c3e50e81298"), true, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6085), "Boleta de Calificaciones", 9876543, "Registro académico", 5120, "Educativo", "ruta/al/documento7" },
                    { new Guid("8f4a67c2-fd5e-4316-8c50-7249f159d0f1"), new Guid("a6509bea-688e-43b5-a870-6ee461ccf601"), true, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6087), "Pasaporte", 1234567, "Documento de viaje", 4096, "Identificación", "ruta/al/documento8" },
                    { new Guid("9b9d6d8f-72f0-4f0a-8e18-1e75b0182e3f"), new Guid("db9fcac5-8654-45c3-87c7-8b5e13e9e6c2"), true, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6090), "Certificado Médico", 543210, "Informe médico", 2048, "Salud", "ruta/al/documento9" },
                    { new Guid("f38f6b1a-86e9-4d9d-8a7a-62f17e6f1ba2"), new Guid("7f255218-f8e0-45a9-9807-12e1bcfd438c"), true, new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(6082), "Carné de Estudiante", 7890123, "Carné escolar", 3072, "Identificación", "ruta/al/documento6" }
                });

            migrationBuilder.InsertData(
                table: "Horarios",
                columns: new[] { "HorarioId", "DiaSemana", "DuracionClaseMinutos", "EstadoHorario", "FechaFinClases", "FechaInicioClases", "GrupoSeccion", "HoraFin", "HoraInicio", "NotificacionCambioHorario", "PeriodoAcademico", "ProfesorAsistente", "SalaAula" },
                values: new object[,]
                {
                    { new Guid("16840dc1-34f1-4148-aa84-eed0c8f50fc9"), "Jueves", 120, "Activo", new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grupo D", new TimeSpan(0, 18, 30, 0, 0), new TimeSpan(0, 16, 30, 0, 0), "Sí", "Semestre de Invierno", "Profesor Asistente 4", "Aula 401" },
                    { new Guid("3844d98a-fafd-4f5e-bc15-65f724499846"), "Martes", 120, "Activo", new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grupo B", new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0), "Sí", "Semestre de Primavera", "Profesor Asistente 2", "Aula 203" },
                    { new Guid("460c3d2b-7dde-4f87-b293-c25dc8cea55c"), "Miércoles", 120, "Activo", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grupo C", new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0), "No", "Semestre de Verano", "Profesor Asistente 3", "Aula 305" },
                    { new Guid("658da267-2633-4f39-98d4-be09059039cd"), "Viernes", 120, "Activo", new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grupo E", new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "No", "Semestre de Primavera", "Profesor Asistente 5", "Aula 102" },
                    { new Guid("9ef9e7ed-7fe8-434b-b8d7-1a1538079249"), "Lunes", 120, "Activo", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grupo A", new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), "No", "Semestre de Otoño", "Profesor Asistente 1", "Aula 101" }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "MateriaId", "DepartamentoAcademico", "Descripcion", "Estado", "GrupoSeccionMateria", "MetodosEnsenanza", "ModalidadEnsenanza", "Nivel", "Nombre", "NotasAdicionales", "ProfesorAsignado" },
                values: new object[,]
                {
                    { new Guid("0a48898d-9e2b-4da0-ae5e-630664883ff4"), "Departamento de Economía", "Curso de Economía Moderna", "En progreso", "Grupo F", "Clases virtuales y análisis económico", "En línea", "Intermedio", "Economía", "Abordaremos temas financieros actuales.", "Profesor Economista" },
                    { new Guid("183491a1-8403-4b0a-afde-7645b1a4ccf4"), "Departamento de Literatura", "Curso de Literatura Universal", "Inscripciones abiertas", "Grupo D", "Lecturas y discusiones literarias", "Presencial", "Intermedio", "Literatura", "Apto para amantes de la lectura.", "Profesor Literario" },
                    { new Guid("68302346-9481-4b79-9439-8618e209e17f"), "Departamento de Informática", "Curso de Ciencias de la Computación", "En progreso", "Grupo C", "Clases virtuales y proyectos prácticos", "En línea", "Avanzado", "Ciencias de la Computación", "Requiere acceso a una computadora.", "Profesor de Informática" },
                    { new Guid("a5c6cb77-2fb2-4e82-b7cd-3837a338d9d6"), "Departamento de Historia", "Curso de Historia Mundial", "Inscripciones abiertas", "Grupo B", "Conferencias y debates", "Presencial", "Intermedio", "Historia", "Recomendado para estudiantes de Historia.", "Profesor Historiador" },
                    { new Guid("c2cf0895-8999-4d74-ba75-aab009b25b8e"), "Departamento de Matemáticas", "Curso de Matemáticas Avanzadas", "En progreso", "Grupo A", "Clases teóricas y prácticas", "Presencial", "Avanzado", "Matemáticas", "Se requiere calculadora científica.", "Profesor Matemático" },
                    { new Guid("c2f8043d-0ad0-4420-9122-248c237606f5"), "Departamento de Arte", "Curso de Arte Contemporáneo", "Inscripciones abiertas", "Grupo G", "Prácticas artísticas y exposiciones", "Presencial", "Intermedio", "Arte", "No se requiere experiencia previa en arte.", "Profesor de Arte" },
                    { new Guid("dbe485f7-72ee-40a3-ae62-1e751b1bb9c4"), "Departamento de Física", "Curso de Física Avanzada", "Completo", "Grupo E", "Experimentos y clases teóricas", "Presencial", "Avanzado", "Física", "Requiere conocimientos previos de física.", "Profesor de Física" }
                });

            migrationBuilder.InsertData(
                table: "Matricula",
                columns: new[] { "MatriculaId", "CategoriaMatricula", "Comentarios", "EstadoMatricula", "FechaMatricula", "InformacionPlanEstudios", "PeriodoAcademico", "RegistroCambios", "TipoMatricula" },
                values: new object[,]
                {
                    { new Guid("1212d56d-5f4a-4b8a-8bac-e8af50c76d7e"), "Estudiante de Tiempo Completo", "Comentario sobre la matrícula 5", "Activa", new DateTime(2024, 6, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7668), "Plan de estudios 2023", 2024, "Registro de cambios 5", "Matrícula Regular" },
                    { new Guid("460056d5-f474-468a-bac6-f4a1a5d8f44a"), "Estudiante de Tiempo Completo", "Comentario sobre la matrícula 1", "Activa", new DateTime(2024, 2, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7653), "Plan de estudios 2023", 2024, "Registro de cambios 1", "Matrícula Regular" },
                    { new Guid("ba71f5a3-bd81-4b4f-aff6-d656d523f86a"), "Estudiante de Tiempo Parcial", "Comentario sobre la matrícula 2", "Pendiente", new DateTime(2024, 3, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7657), "Plan de estudios 2023", 2024, "Registro de cambios 2", "Matrícula Parcial" },
                    { new Guid("dcbd5037-9e2a-49c9-a309-e9f4a622a967"), "Estudiante de Tiempo Completo", "Comentario sobre la matrícula 4", "Activa", new DateTime(2024, 5, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7663), "Plan de estudios 2023", 2024, "Registro de cambios 4", "Matrícula Regular" },
                    { new Guid("de0f2394-a4a0-49ea-8888-37b2653eb650"), "Estudiante Internacional", "Comentario sobre la matrícula 3", "Cancelada", new DateTime(2024, 4, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7661), "Plan de estudios 2023", 2024, "Registro de cambios 3", "Matrícula Regular" }
                });

            migrationBuilder.InsertData(
                table: "PreMatricula",
                columns: new[] { "PreMatriculaId", "EstadoPreMatricula", "GradoONivel", "Observaciones", "RequisitosDocumentacion", "Turno" },
                values: new object[,]
                {
                    { new Guid("1e203d42-9b7d-4bbe-84fa-0168ab06abe5"), "Activa", "Cuarto de Secundaria", "Estudiante con beca deportiva.", "SiCumplio", "Tarde" },
                    { new Guid("2345c21b-69d3-4fca-87a5-04e90c84cbc8"), "Pendiente", "Quinto de Primaria", "Estudiante con requerimientos especiales.", "NoCumplio", "Mañana" },
                    { new Guid("3eec71e2-cc13-4b58-8fd9-8dd48c1b955f"), "Activa", "Séptimo de Secundaria", "Estudiante de transferencia.", "SiCumplio", "Tarde" },
                    { new Guid("4b94fb18-48e1-4312-9e8f-e5c60d4aa52a"), "Pendiente", "Tercero de Primaria", "Estudiante extranjero.", "SiCumplio", "Mañana" },
                    { new Guid("dfee6f54-9d82-4ae1-a7d5-a800b10e0402"), "Pendiente", "Octavo de Secundaria", "Estudiante sin observaciones adicionales.", "Si cumplio", "Tarde" },
                    { new Guid("f70f2817-6c4c-4317-98ea-2ed90762b36d"), "Activa", "Segundo de Primaria", "Estudiante con discapacidad visual.", "SiCumplio", "Mañana" }
                });

            migrationBuilder.InsertData(
                table: "RespuestaCupo",
                columns: new[] { "RespuestaCupoId", "DuracionRespuesta", "EstadoRespuesta", "FechaRespuesta", "FechaVencimiento", "MensajeRespuesta", "Prioridad", "TipoRespuesta", "UsuarioRespuesta" },
                values: new object[,]
                {
                    { new Guid("0a5d3972-b0e0-49ec-aef8-19f0d80d938f"), new TimeSpan(45, 0, 0, 0, 0), "Rechazada", new DateTime(2024, 2, 9, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7221), new DateTime(2024, 7, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7221), "Respuesta 5", "Media", "Rechazo", "Usuario5" },
                    { new Guid("10b90ed5-8bb8-4f2e-bd15-4857fd932dcd"), new TimeSpan(30, 0, 0, 0, 0), "Aceptada", new DateTime(2024, 2, 5, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7198), new DateTime(2024, 3, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7204), "Respuesta 1", "Alta", "Aceptación", "Usuario1" },
                    { new Guid("49f896d0-04f3-436f-91c1-826fbbeb55da"), new TimeSpan(45, 0, 0, 0, 0), "Rechazada", new DateTime(2024, 2, 6, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7210), new DateTime(2024, 4, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7211), "Respuesta 2", "Media", "Rechazo", "Usuario2" },
                    { new Guid("5944f4a6-bf5a-4c7e-83c6-9d77f5664bb8"), new TimeSpan(45, 0, 0, 0, 0), "Rechazada", new DateTime(2024, 2, 11, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7226), new DateTime(2024, 9, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7227), "Respuesta 7", "Media", "Rechazo", "Usuario7" },
                    { new Guid("68fcaba0-7c27-4372-a111-fc26349c5b3d"), new TimeSpan(30, 0, 0, 0, 0), "Aceptada", new DateTime(2024, 2, 13, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7231), new DateTime(2024, 11, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7232), "Respuesta 9", "Alta", "Aceptación", "Usuario9" },
                    { new Guid("789a22df-5294-47cf-af46-53d9fde9fa86"), new TimeSpan(60, 0, 0, 0, 0), "Pendiente", new DateTime(2024, 2, 12, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7229), new DateTime(2024, 10, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7229), "Respuesta 8", "Baja", "Pendiente", "Usuario8" },
                    { new Guid("7dfc3fab-584f-4060-be48-1ed5d03c0972"), new TimeSpan(30, 0, 0, 0, 0), "Aceptada", new DateTime(2024, 2, 10, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7223), new DateTime(2024, 8, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7224), "Respuesta 6", "Alta", "Aceptación", "Usuario6" },
                    { new Guid("a9522efb-ae0e-4ee3-b221-7a70cd298df0"), new TimeSpan(30, 0, 0, 0, 0), "Aceptada", new DateTime(2024, 2, 8, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7218), new DateTime(2024, 6, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7219), "Respuesta 4", "Alta", "Aceptación", "Usuario4" },
                    { new Guid("d18b00d0-dd4a-4ebf-8339-a8a2470e2742"), new TimeSpan(60, 0, 0, 0, 0), "Pendiente", new DateTime(2024, 2, 7, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7213), new DateTime(2024, 5, 4, 16, 7, 21, 846, DateTimeKind.Local).AddTicks(7214), "Respuesta 3", "Baja", "Pendiente", "Usuario3" }
                });

            migrationBuilder.InsertData(
                table: "TelefonoAcudiente",
                columns: new[] { "TelefonoAcudienteId", "AcudienteId", "Indicativo", "Numero", "Tipo" },
                values: new object[,]
                {
                    { new Guid("08fe1deb-a3d4-43c4-9c60-2c511d544370"), 3, "+1", -5357, "Fijo" },
                    { new Guid("13380ff2-fb3f-4640-ad8c-6168a37014a7"), 4, "+1", -4333, "Móvil" },
                    { new Guid("4502dbae-1482-4d71-a625-9a1d93db5b71"), 5, "+1", 911, "Emergencia" },
                    { new Guid("53b3f7c5-7e02-44f4-aba6-72d183a048f6"), 5, "+1", -5555, "Emergencia" },
                    { new Guid("8c760710-ccae-487b-a173-4ac1cb961806"), 1, "+1", -667, "Móvil" },
                    { new Guid("98f4bc5e-f60b-494a-876b-db81838f186c"), 4, "+1", -5753, "Móvil" },
                    { new Guid("b2fa0b63-ebb4-4f92-8b03-c81c019cc0d9"), 2, "+1", -1889, "Móvil" },
                    { new Guid("b9bf66ae-756e-4c76-9253-f836b13ebe02"), 1, "+1", -4135, "Móvil" },
                    { new Guid("c0af4df5-4c25-469b-bdb2-e5e799a0e040"), 3, "+1", -3111, "Fijo" },
                    { new Guid("d8624544-37e2-4ca1-aaf3-8e53e79296db"), 2, "+1", -6975, "Móvil" }
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
