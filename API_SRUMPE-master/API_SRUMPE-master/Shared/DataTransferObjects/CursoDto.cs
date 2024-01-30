
namespace Shared.DataTransferObjects;

public record CursoDto
{
    public Guid CursoId { get; set; }
    public int Curso { get; set; }
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
    public string DepartamentoAcademico { get; set; }
    public string Nivel { get; set; }
    public string ProfesorAsignado { get; set; }
    public string AulasAsignadas { get; set; }
    public DateTime FechaLimiteInscripcion { get; set; }
    public string MetodosEnsenanza { get; set; }
}