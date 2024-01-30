namespace Service.Contracts;

public interface IServiceManager
{
	ICandidatoEstudianteService CandidatoEstudianteService { get; }
    IEstudianteDocumentosService EstudianteDocumentosService { get; }
    IAcudienteService AcudienteService { get; }
    IDireccionAcudienteService DireccionAcudienteService { get; }
    ITelefonoAcudienteService TelefonoAcudienteService { get; }
    ICupoService CupoService { get; }
    IRespuestaCupoService RespuestaCupoService { get; }
    IPreMatriculaService PreMatriculaService { get; }
    IMatriculaService MatriculaService { get; }
    IAulaService AulaService { get; }
    ICursoService CursoService { get; }
    IHorarioService HorarioService { get; }
    IMateriaService MateriaService { get; }
    IAsistenciaService AsistenciaService { get; }
    IEstadisticaService EstadisticaService { get; }
}

