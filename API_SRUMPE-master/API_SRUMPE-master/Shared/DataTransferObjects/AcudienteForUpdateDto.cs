using Entities.Models.D_Acudiente;

namespace Shared.DataTransferObjects
{
    public record AcudienteForUpdateDto (string Nombres,string Apellidos,int NumeroIdentificacion,string Genero, DateTime FechaNacimiento,string CorreoElectronico, string RelacionConEstudiante,string EstadoCivil, string Ocupacion, bool Estado, DateTime FechaRegistro)
    {
        public static Acudiente MapToAcudiente(AcudienteForUpdateDto dto)
        {
            return new Acudiente
            {
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                NumeroIdentificacion = dto.NumeroIdentificacion,
                Genero = dto.Genero,
                FechaNacimiento = dto.FechaNacimiento,
                CorreoElectronico = dto.CorreoElectronico,
                RelacionConEstudiante = dto.RelacionConEstudiante,
                EstadoCivil = dto.EstadoCivil,
                Ocupacion = dto.Ocupacion,
                Estado = dto.Estado,
                FechaRegistro = dto.FechaRegistro,
            };
        }
    }
}