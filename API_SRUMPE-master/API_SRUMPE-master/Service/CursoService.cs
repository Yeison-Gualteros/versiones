using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.D_DepartamentoAcademico;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace Service;
internal sealed class CursoService : ICursoService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CursoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CursoDto> GetAllCursos(bool trackChanges)
    {
        var cursos = _repository.Curso.GetAllCursos(trackChanges);

        var cursoDto = _mapper.Map<IEnumerable<CursoDto>>(cursos);

        return cursoDto;
    }

    public CursoDto GetCurso(Guid id, bool trackChanges)
    {
        var curso = _repository.Curso.GetCurso(id, trackChanges);
        if (curso is null)
            throw new CursoNotFoundException(id);

        var cursoDto = _mapper.Map<CursoDto>(curso);
        return cursoDto;
    }

    public CursoDto CreateCurso(CursoForCreationDto curso)
    {
        var cursoEntity = _mapper.Map<Cursos>(curso);

        _repository.Curso.CreateCurso(cursoEntity);
        _repository.Save();

        var cursoToReturn = _mapper.Map<CursoDto>(cursoEntity);

        return cursoToReturn;
    }

    public IEnumerable<CursoDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var cursoEntities = _repository.Curso.GetByIds(ids, trackChanges);
        if (ids.Count() != cursoEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var cursosToReturn = _mapper.Map<IEnumerable<CursoDto>>(cursoEntities);

        return cursosToReturn;
    }

    public (IEnumerable<CursoDto> cursos, string ids) CreateCursoCollection
        (IEnumerable<CursoForCreationDto> cursoCollection)
    {
        if (cursoCollection is null)
            throw new CursoCollectionBadRequest();

        var cursoEntities = _mapper.Map<IEnumerable<Cursos>>(cursoCollection);
        foreach (var curso in cursoEntities)
        {
            _repository.Curso.CreateCurso(curso);
        }

        _repository.Save();

        var cursoCollectionToReturn = _mapper.Map<IEnumerable<CursoDto>>(cursoEntities);
        var ids = string.Join(",", cursoCollectionToReturn.Select(c => c.CursoId));

        return (cursos: cursoCollectionToReturn, ids: ids);
    }

    public void DeleteCurso(Guid cursoId, bool trackChanges)
    {
        var curso = _repository.Curso.GetCurso(cursoId, trackChanges);
        if (curso is null)
        {
            throw new CursoNotFoundException(cursoId);
        }

        _repository.Curso.DeleteCurso(curso);
        _repository.Save();
    }

    public void UpdateCurso(Guid cursoId, CursoForUpdateDto cursoForUpdate, bool trackChanges)
    {
        var cursoEntity = _repository.Curso.GetCurso(cursoId, trackChanges);
        if (cursoEntity is null)
            throw new CursoNotFoundException(cursoId);
        _mapper.Map(cursoForUpdate, cursoEntity);
        _repository.Save();
    }
}
