using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Entities.Models.D_Acudiente;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;
internal sealed class TelefonoAcudienteService : ITelefonoAcudienteService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public TelefonoAcudienteService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<TelefonoAcudienteDto> GetAllTelefonoAcudientes(bool trackChanges)
    {
        var telefonoAcudientes = _repository.TelefonoAcudiente.GetAllTelefonoAcudientes(trackChanges);

        var telefonoAcudientesDto = _mapper.Map<IEnumerable<TelefonoAcudienteDto>>(telefonoAcudientes);

        return telefonoAcudientesDto;
    }

    public TelefonoAcudienteDto GetTelefonoAcudiente(Guid id, bool trackChanges)
    {
        var telefonoAcudiente = _repository.TelefonoAcudiente.GetTelefonoAcudiente(id, trackChanges);
        if (telefonoAcudiente is null)
            throw new TelefonoAcudienteNotFoundException(id);

        var telefonoAcudienteDto = _mapper.Map<TelefonoAcudienteDto>(telefonoAcudiente);
        return telefonoAcudienteDto;
    }

    public TelefonoAcudienteDto CreateTelefonoAcudiente(TelefonoAcudienteForCreationDto telefonoAcudiente)
    {
        var telefonoAcudienteEntity = _mapper.Map<TelefonoAcudiente>(telefonoAcudiente);

        _repository.TelefonoAcudiente.CreateTelefonoAcudiente(telefonoAcudienteEntity);
        _repository.Save();

        var telefonoAcudienteToReturn = _mapper.Map<TelefonoAcudienteDto>(telefonoAcudienteEntity);

        return telefonoAcudienteToReturn;
    }

    public IEnumerable<TelefonoAcudienteDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var telefonoAcudienteEntities = _repository.TelefonoAcudiente.GetByIds(ids, trackChanges);
        if (ids.Count() != telefonoAcudienteEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var telefonoAcudientesToReturn = _mapper.Map<IEnumerable<TelefonoAcudienteDto>>(telefonoAcudienteEntities);

        return telefonoAcudientesToReturn;
    }

    public (IEnumerable<TelefonoAcudienteDto> telefonoAcudientes, string ids) CreateTelefonoAcudienteCollection
        (IEnumerable<TelefonoAcudienteForCreationDto> telefonoAcudienteCollection)
    {
        if (telefonoAcudienteCollection is null)
            throw new TelefonoAcudienteCollectionBadRequest();

        var telefonoAcudienteEntities = _mapper.Map<IEnumerable<TelefonoAcudiente>>(telefonoAcudienteCollection);
        foreach (var telefonoAcudiente in telefonoAcudienteEntities)
        {
            _repository.TelefonoAcudiente.CreateTelefonoAcudiente(telefonoAcudiente);
        }

        _repository.Save();

        var telefonoAcudienteCollectionToReturn = _mapper.Map<IEnumerable<TelefonoAcudienteDto>>(telefonoAcudienteEntities);
        var ids = string.Join(",", telefonoAcudienteCollectionToReturn.Select(t => t.TelefonoAcudienteId));

        return (telefonoAcudientes: telefonoAcudienteCollectionToReturn, ids: ids);
    }

    public void DeleteTelefonoAcudiente(Guid telefonoAcudienteId, bool trackChanges)
    {
        var telefonoAcudiente = _repository.TelefonoAcudiente.GetTelefonoAcudiente(telefonoAcudienteId, trackChanges);
        if (telefonoAcudiente is null)
        {
            throw new TelefonoAcudienteNotFoundException(telefonoAcudienteId);
        }

        _repository.TelefonoAcudiente.DeleteTelefonoAcudiente(telefonoAcudiente);
        _repository.Save();
    }

    public void UpdateTelefonoAcudiente(Guid telefonoAcudienteId, TelefonoAcudienteForUpdateDto telefonoAcudienteForUpdate, bool trackChanges)
    {
        var telefonoAcudienteEntity = _repository.TelefonoAcudiente.GetTelefonoAcudiente(telefonoAcudienteId, trackChanges);
        if (telefonoAcudienteEntity is null)
            throw new TelefonoAcudienteNotFoundException(telefonoAcudienteId);
        _mapper.Map(telefonoAcudienteForUpdate, telefonoAcudienteEntity);
        _repository.Save();
    }
}

