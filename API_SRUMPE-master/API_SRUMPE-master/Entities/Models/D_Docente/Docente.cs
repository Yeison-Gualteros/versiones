namespace Entities.Models.D_Docente
{
    public partial class Docente
    {
        public int DocenteId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroTelefono { get; set; }
        public DateTime FechaContratacion { get; set; }
        public string CursosAsignados { get; set; }
        public string HorarioClases { get; set; }
        public string EstadoLaboral { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Supervisor { get; set; }
        public string AsistenciaAusencias { get; set; }
        public string ComentariosNotas { get; set; }
        public string NivelExperiencia { get; set; }
        public byte[] Fotografia { get; set; }
    }
}
