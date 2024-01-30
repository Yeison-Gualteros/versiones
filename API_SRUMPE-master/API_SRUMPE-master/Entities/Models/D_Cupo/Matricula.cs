namespace Entities.Models
{
    public partial class Matricula
    {
        //public Guid PreMatriculaId { get; set; }
        //public Guid CandidatoEstudianteId { get; set; }
        //public Guid CursoId { get; set; }
        public Guid MatriculaId { get; set; }
        public DateTime FechaMatricula { get; set; }
        public string EstadoMatricula { get; set; }
        public string TipoMatricula { get; set; }
        public int PeriodoAcademico { get; set; }
        public string Comentarios { get; set; }
        public string CategoriaMatricula { get; set; }
        public string InformacionPlanEstudios { get; set; }
        public string RegistroCambios { get; set; }
    }
}