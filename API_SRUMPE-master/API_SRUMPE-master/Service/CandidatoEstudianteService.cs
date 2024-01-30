using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.D_Estudiante;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class CandidatoEstudianteService : ICandidatoEstudianteService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CandidatoEstudianteService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CandidatoEstudianteDto> GetAllCandidatoEstudiantes(bool trackChanges)
    {
        var candidatoEstudiantes = _repository.CandidatoEstudiante.GetAllCandidatoEstudiantes(trackChanges);

        var candidatoEstudiantesDto = _mapper.Map<IEnumerable<CandidatoEstudianteDto>>(candidatoEstudiantes);

        return candidatoEstudiantesDto;
    }

    public CandidatoEstudianteDto GetCandidatoEstudiante(Guid id, bool trackChanges)
    {
        var candidatoEstudiante = _repository.CandidatoEstudiante.GetCandidatoEstudiante(id, trackChanges);
        if (candidatoEstudiante is null)
            throw new CandidatoEstudianteNotFoundException(id);

        var candidatoEstudianteDto = _mapper.Map<CandidatoEstudianteDto>(candidatoEstudiante);
        return candidatoEstudianteDto;
    }

    public CandidatoEstudianteDto CreateCandidatoEstudiante(CandidatoEstudianteForCreationDto candidatoEstudiante)
    {
        var candidatoEstudianteEntity = _mapper.Map<CandidatoEstudiante>(candidatoEstudiante);

        _repository.CandidatoEstudiante.CreateCandidatoEstudiante(candidatoEstudianteEntity);
        _repository.Save();

        var candidatoEstudianteToReturn = _mapper.Map<CandidatoEstudianteDto>(candidatoEstudianteEntity);

        return candidatoEstudianteToReturn;
    }

    public IEnumerable<CandidatoEstudianteDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var candidatoEstudianteEntities = _repository.CandidatoEstudiante.GetByIds(ids, trackChanges);
        if (ids.Count() != candidatoEstudianteEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var candidatoEstudiantesToReturn = _mapper.Map<IEnumerable<CandidatoEstudianteDto>>(candidatoEstudianteEntities);

        return candidatoEstudiantesToReturn;
    }

    public (IEnumerable<CandidatoEstudianteDto> candidatoEstudiantes, string ids) CreateCandidatoEstudianteCollection
        (IEnumerable<CandidatoEstudianteForCreationDto> candidatoEstudianteCollection)
    {
        if (candidatoEstudianteCollection is null)
            throw new CandidatoEstudianteCollectionBadRequest();

        var candidatoEstudianteEntities = _mapper.Map<IEnumerable<CandidatoEstudiante>>(candidatoEstudianteCollection);
        foreach (var candidatoEstudiante in candidatoEstudianteEntities)
        {
            _repository.CandidatoEstudiante.CreateCandidatoEstudiante(candidatoEstudiante);
        }

        _repository.Save();

        var candidatoEstudianteCollectionToReturn = _mapper.Map<IEnumerable<CandidatoEstudianteDto>>(candidatoEstudianteEntities);
        var ids = string.Join(",", candidatoEstudianteCollectionToReturn.Select(c => c.CandidatoEstudianteId));

        return (candidatoEstudiantes: candidatoEstudianteCollectionToReturn, ids: ids);
    }
    public void DeleteCandidatoEstudiante(Guid candidatoEstudianteId, bool trackChanges)
    {
        var candidatoEstudiante = _repository.CandidatoEstudiante.GetCandidatoEstudiante(candidatoEstudianteId, trackChanges);
        if (candidatoEstudiante is null)
        {
            throw new CandidatoEstudianteNotFoundException(candidatoEstudianteId);
        }

        _repository.CandidatoEstudiante.DeleteCandidatoEstudiante(candidatoEstudiante);
        _repository.Save();

    }
    public void UpdateCandidatoEstudiante(Guid candidatoEstudianteId, CandidatoEstudianteForUpdateDto candidatoEstudianteForUpdate, bool trackChanges)
    {
        var candidatoEstudianteEntity = _repository.CandidatoEstudiante.GetCandidatoEstudiante(candidatoEstudianteId, trackChanges);
        if (candidatoEstudianteEntity is null)
            throw new CandidatoEstudianteNotFoundException(candidatoEstudianteId);
        _mapper.Map(candidatoEstudianteForUpdate, candidatoEstudianteEntity);
        _repository.Save();
    }
}



