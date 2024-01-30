
namespace Entities.Models
{
    public partial class SoportesEmpleado
    {
        public int SoportesEmpleadoId { get; set; }
        //public int IdDocente { get; set; }
        public string TipoSoporte { get; set; }
        public string NombreSoporte { get; set; }
        public string InstitucionEducativa { get; set; }
        public DateTime FechaObtencion { get; set; }
        public string NivelAcademico { get; set; }
        public string Descripcion { get; set; }
        public byte[] ArchivoAdjunto { get; set; }
        public string EstadoSoporte { get; set; }
        public DateTime FechaCreacionRegistro { get; set; }
        public string ComentariosNotas { get; set; }
        public string ReferenciasContactosEmergencia { get; set; }
        public string PermisosLicenciasEspeciales { get; set; }
        public string EstadoLaboral { get; set; }
    }
}
