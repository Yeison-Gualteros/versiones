namespace Shared.DataTransferObjects;

public record AcudienteForCreationDto( string Nombres, string Apellidos, int NumeroIdentificacion, string Genero, DateTime FechaNacimiento, string CorreoElectronico, string RelacionConEstudiante, string EstadoCivil, string Ocupacion, bool Estado, DateTime FechaRegistro,
    IEnumerable<AcudienteForCreationDto>? Acudientes);


