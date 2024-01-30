using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICandidatoEstudianteService> _candidatoEstudianteService;
    private readonly Lazy<IEstudianteDocumentosService> _estudianteDocumentosService;
    private readonly Lazy<IAcudienteService> _acudienteService;
    private readonly Lazy<IDireccionAcudienteService> _direccionAcudienteService;
    private readonly Lazy<ITelefonoAcudienteService> _telefonoAcudienteService;
    private readonly Lazy<ICupoService> _cupoService;
    private readonly Lazy<IRespuestaCupoService> _respuestaCupoService;
    private readonly Lazy<IPreMatriculaService> _preMatriculaService;
    private readonly Lazy<IMatriculaService> _matriculaService;
    private readonly Lazy<IAulaService> _aulaService;
    private readonly Lazy<ICursoService> _cursoService;
    private readonly Lazy<IHorarioService> _horarioService;
    private readonly Lazy<IMateriaService> _materiaService;
    private readonly Lazy<IAsistenciaService> _asistenciaService;
    private readonly Lazy<IEstadisticaService> _estadisticaService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _candidatoEstudianteService = new Lazy<ICandidatoEstudianteService>(() =>
            new CandidatoEstudianteService(repositoryManager, logger, mapper));

        _estudianteDocumentosService = new Lazy<IEstudianteDocumentosService>(() =>
            new EstudianteDocumentosService(repositoryManager, logger, mapper));

        _acudienteService = new Lazy<IAcudienteService>(() =>
            new AcudienteService(repositoryManager, logger, mapper));

        _direccionAcudienteService = new Lazy<IDireccionAcudienteService>(() =>
            new DireccionAcudienteService(repositoryManager, logger, mapper));

        _telefonoAcudienteService = new Lazy<ITelefonoAcudienteService>(() =>
            new TelefonoAcudienteService(repositoryManager, logger, mapper));

        _cupoService = new Lazy<ICupoService>(() =>
            new CupoService(repositoryManager, logger, mapper));
        
        _respuestaCupoService = new Lazy<IRespuestaCupoService>(() =>
            new RespuestaCupoService(repositoryManager, logger, mapper));

        _preMatriculaService = new Lazy<IPreMatriculaService>(() =>
            new PreMatriculaService(repositoryManager, logger, mapper));
        _matriculaService = new Lazy<IMatriculaService>(() =>
            new MatriculaService(repositoryManager, logger, mapper));
        _aulaService = new Lazy<IAulaService>(() =>
            new AulaService(repositoryManager, logger, mapper));
        _cursoService = new Lazy<ICursoService>(() =>
            new CursoService(repositoryManager, logger, mapper));
        _horarioService = new Lazy<IHorarioService>(() =>
            new HorarioService(repositoryManager, logger, mapper));
        _materiaService = new Lazy<IMateriaService>(() =>
            new MateriaService(repositoryManager, logger, mapper));
        _asistenciaService = new Lazy<IAsistenciaService>(() =>
            new AsistenciaService(repositoryManager, logger, mapper));
        _estadisticaService = new Lazy<IEstadisticaService>(() =>
            new EstadisticaService(repositoryManager, logger, mapper));


    }

    public ICandidatoEstudianteService CandidatoEstudianteService => _candidatoEstudianteService.Value;
    public IEstudianteDocumentosService EstudianteDocumentosService => _estudianteDocumentosService.Value;
    public IAcudienteService AcudienteService => _acudienteService.Value;
    public IDireccionAcudienteService DireccionAcudienteService => _direccionAcudienteService.Value;
    public ITelefonoAcudienteService TelefonoAcudienteService => _telefonoAcudienteService.Value;
    public ICupoService CupoService => _cupoService.Value;
    public IRespuestaCupoService RespuestaCupoService => _respuestaCupoService.Value;
    public IPreMatriculaService PreMatriculaService => _preMatriculaService.Value;
    public IMatriculaService MatriculaService => _matriculaService.Value;
    public IAulaService AulaService => _aulaService.Value;
    public ICursoService CursoService => _cursoService.Value;
    public IHorarioService HorarioService => _horarioService.Value;
    public IMateriaService MateriaService => _materiaService.Value;
    public IAsistenciaService AsistenciaService => _asistenciaService.Value;
    public IEstadisticaService EstadisticaService => _estadisticaService.Value;
}



