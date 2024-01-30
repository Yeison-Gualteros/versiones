using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.D_Acudiente;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class AcudienteService : IAcudienteService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public AcudienteService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<AcudienteDto> GetAllAcudiente(bool trackChanges)
    {
        var acudientes = _repository.Acudiente.GetAllAcudientes(trackChanges);

        var acudientesDto = _mapper.Map<IEnumerable<AcudienteDto>>(acudientes);

        return acudientesDto;
    }

    public AcudienteDto GetAcudiente(Guid id, bool trackChanges)
    {
        var acudiente = _repository.Acudiente.GetAcudiente(id, trackChanges);
        if (acudiente is null)
            throw new AcudienteNotFoundException(id);

        var acudienteDto = _mapper.Map<AcudienteDto>(acudiente);
        return acudienteDto;
    }

    public AcudienteDto CreateAcudiente(AcudienteForCreationDto acudiente)
    {
        var acudienteEntity = _mapper.Map<Acudiente>(acudiente);

        _repository.Acudiente.CreateAcudiente(acudienteEntity);
        _repository.Save();

        var acudienteToReturn = _mapper.Map<AcudienteDto>(acudienteEntity);

        return acudienteToReturn;
    }

    public IEnumerable<AcudienteDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var acudienteEntities = _repository.Acudiente.GetByIds(ids, trackChanges);
        if (ids.Count() != acudienteEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var acudientesToReturn = _mapper.Map<IEnumerable<AcudienteDto>>(acudienteEntities);

        return acudientesToReturn;
    }

    public void DeleteAcudiente(Guid acudienteId, bool trackChanges)
    {
        var acudiente = _repository.Acudiente.GetAcudiente(acudienteId, trackChanges);
        if (acudiente is null)
        {
            throw new AcudienteNotFoundException(acudienteId);
        }

        _repository.Acudiente.DeleteAcudiente(acudiente);
        _repository.Save();
    }

    public void UpdateAcudiente(Guid acudienteId, AcudienteForUpdateDto acudienteForUpdate, bool trackChanges)
    {
        var acudienteEntity = _repository.Acudiente.GetAcudiente(acudienteId, trackChanges);
        if (acudienteEntity is null)
            throw new AcudienteNotFoundException(acudienteId);
        _mapper.Map(acudienteForUpdate, acudienteEntity);
        _repository.Save();
    }

    public (IEnumerable<AcudienteDto> acudiente, string ids) CreateAcudienteCollection(IEnumerable<AcudienteForCreationDto> acudienteCollection)
    {
        if (acudienteCollection is null)
            throw new AcudienteCollectionBadRequest();

        var acudienteEntities = _mapper.Map<IEnumerable<Acudiente>>(acudienteCollection);
        foreach (var acudiente in acudienteEntities)
        {
            _repository.Acudiente.CreateAcudiente(acudiente);
        }

        _repository.Save();

        var acudienteCollectionToReturn = _mapper.Map<IEnumerable<AcudienteDto>>(acudienteEntities);
        var ids = string.Join(",", acudienteCollectionToReturn.Select(c => c.AcudienteId));

        return (acudientes: acudienteCollectionToReturn, ids: ids);
    }
}
