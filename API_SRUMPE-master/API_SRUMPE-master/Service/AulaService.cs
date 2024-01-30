using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.D_DepartamentoAcademico;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;
internal sealed class AulaService : IAulaService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public AulaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<AulaDto> GetAllAulas(bool trackChanges)
    {
        var aula = _repository.Aula.GetAllAulas(trackChanges);

        var aulaDto = _mapper.Map<IEnumerable<AulaDto>>(aula);

        return aulaDto;
    }

    public AulaDto GetAula(Guid id, bool trackChanges)
    {
        var aula = _repository.Aula.GetAula(id, trackChanges);
        if (aula is null)
            throw new AulaNotFoundException(id);

        var aulaDto = _mapper.Map<AulaDto>(aula);
        return aulaDto;
    }

    public AulaDto CreateAula(AulaForCreationDto aula)
    {
        var aulaEntity = _mapper.Map<Aulas>(aula);

        _repository.Aula.CreateAula(aulaEntity);
        _repository.Save();

        var aulaToReturn = _mapper.Map<AulaDto>(aulaEntity);

        return aulaToReturn;
    }

    public IEnumerable<AulaDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var aulaEntities = _repository.Aula.GetByIds(ids, trackChanges);
        if (ids.Count() != aulaEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var aulasToReturn = _mapper.Map<IEnumerable<AulaDto>>(aulaEntities);

        return aulasToReturn;
    }

    public (IEnumerable<AulaDto> aulas, string ids) CreateAulaCollection
        (IEnumerable<AulaForCreationDto> aulaCollection)
    {
        if (aulaCollection is null)
            throw new AulaCollectionBadRequest();

        var aulaEntities = _mapper.Map<IEnumerable<Aulas>>(aulaCollection);
        foreach (var aula in aulaEntities)
        {
            _repository.Aula.CreateAula(aula);
        }

        _repository.Save();

        var aulaCollectionToReturn = _mapper.Map<IEnumerable<AulaDto>>(aulaEntities);
        var ids = string.Join(",", aulaCollectionToReturn.Select(a => a.AulaId));

        return (aulas: aulaCollectionToReturn, ids: ids);
    }

    public void DeleteAula(Guid aulaId, bool trackChanges)
    {
        var aula = _repository.Aula.GetAula(aulaId, trackChanges);
        if (aula is null)
        {
            throw new AulaNotFoundException(aulaId);
        }

        _repository.Aula.DeleteAula(aula);
        _repository.Save();
    }

    public void UpdateAula(Guid aulaId, AulaForUpdateDto aulaForUpdate, bool trackChanges)
    {
        var aulaEntity = _repository.Aula.GetAula(aulaId, trackChanges);
        if (aulaEntity is null)
            throw new AulaNotFoundException(aulaId);
        _mapper.Map(aulaForUpdate, aulaEntity);
        _repository.Save();
    }
}
