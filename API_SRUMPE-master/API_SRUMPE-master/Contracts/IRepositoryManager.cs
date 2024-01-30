namespace Contracts;

public interface IRepositoryManager
{
	ICandidatoEstudianteRepository CandidatoEstudiante { get; }
	IEstudianteDocumentosRepository EstudianteDocumentos { get; }
    IAcudienteRepository Acudiente { get; }
    IDireccionAcudienteRepository DireccionAcudiente { get; }
    ITelefonoAcudienteRepository TelefonoAcudiente { get; }
    ICupoRepository Cupo { get; }
    IRespuestaCupoRepository RespuestaCupo { get; }
    IPreMatriculaRepository PreMatricula { get; }
    IMatriculaRepository Matricula { get; }
    IAulaRepository Aula { get; }
    ICursoRepository Curso { get; }
    IHorarioRepository Horario { get; }
    IMateriaRepository Materia { get; }
    IAsistenciaRepository Asistencia { get; }
    IEstadisticaRepository Estadistica { get; }
    void Save();
}
