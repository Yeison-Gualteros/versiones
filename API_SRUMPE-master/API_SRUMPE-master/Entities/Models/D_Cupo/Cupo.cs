namespace Entities.Models.D_Estudiante
{
    public partial class Cupo
    {
        public Guid CupoId { get; set; }
        public int CantidadDisponible { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Descripcion { get; set; }
        public string? Ubicacion { get; set; }
        public bool Estado { get; set; }
        public TimeSpan Duracion { get; set; }

        //public Guid CandidatoEstudianteId { get; set; }
    }
}
