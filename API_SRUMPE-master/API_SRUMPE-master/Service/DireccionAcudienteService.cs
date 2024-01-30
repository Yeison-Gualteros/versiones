using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.D_Acudiente;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class DireccionAcudienteService : IDireccionAcudienteService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public DireccionAcudienteService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<DireccionAcudienteDto> GetAllDireccionAcudientes(bool trackChanges)
    {
        var direccionAcudientes = _repository.DireccionAcudiente.GetAllDireccionAcudientes(trackChanges);

        var direccionAcudientesDto = _mapper.Map<IEnumerable<DireccionAcudienteDto>>(direccionAcudientes);

        return direccionAcudientesDto;
    }

    public DireccionAcudienteDto GetDireccionAcudiente(Guid id, bool trackChanges)
    {
        var direccionAcudiente = _repository.DireccionAcudiente.GetDireccionAcudiente(id, trackChanges);
        if (direccionAcudiente is null)
            throw new DireccionAcudienteNotFoundException(id);

        var direccionAcudienteDto = _mapper.Map<DireccionAcudienteDto>(direccionAcudiente);
        return direccionAcudienteDto;
    }

    public DireccionAcudienteDto CreateDireccionAcudiente(DireccionAcudienteForCreationDto direccionAcudiente)
    {
        var direccionAcudienteEntity = _mapper.Map<DireccionAcudiente>(direccionAcudiente);

        _repository.DireccionAcudiente.CreateDireccionAcudiente(direccionAcudienteEntity);
        _repository.Save();

        var direccionAcudienteToReturn = _mapper.Map<DireccionAcudienteDto>(direccionAcudienteEntity);

        return direccionAcudienteToReturn;
    }

    public IEnumerable<DireccionAcudienteDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var direccionAcudienteEntities = _repository.DireccionAcudiente.GetByIds(ids, trackChanges);
        if (ids.Count() != direccionAcudienteEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var direccionAcudientesToReturn = _mapper.Map<IEnumerable<DireccionAcudienteDto>>(direccionAcudienteEntities);

        return direccionAcudientesToReturn;
    }

    public (IEnumerable<DireccionAcudienteDto> direccionAcudientes, string ids) CreateDireccionAcudienteCollection
        (IEnumerable<DireccionAcudienteForCreationDto> direccionAcudienteCollection)
    {
        if (direccionAcudienteCollection is null)
            throw new DireccionAcudienteCollectionBadRequest();

        var direccionAcudienteEntities = _mapper.Map<IEnumerable<DireccionAcudiente>>(direccionAcudienteCollection);
        foreach (var direccionAcudiente in direccionAcudienteEntities)
        {
            _repository.DireccionAcudiente.CreateDireccionAcudiente(direccionAcudiente);
        }

        _repository.Save();

        var direccionAcudienteCollectionToReturn = _mapper.Map<IEnumerable<DireccionAcudienteDto>>(direccionAcudienteEntities);
        var ids = string.Join(",", direccionAcudienteCollectionToReturn.Select(c => c.DireccionAcudienteId));

        return (direccionAcudientes: direccionAcudienteCollectionToReturn, ids: ids);
    }

    public void DeleteDireccionAcudiente(Guid direccionAcudienteId, bool trackChanges)
    {
        var direccionAcudiente = _repository.DireccionAcudiente.GetDireccionAcudiente(direccionAcudienteId, trackChanges);
        if (direccionAcudiente is null)
        {
            throw new DireccionAcudienteNotFoundException(direccionAcudienteId);
        }

        _repository.DireccionAcudiente.DeleteDireccionAcudiente(direccionAcudiente);
        _repository.Save();
    }

    public void UpdateDireccionAcudiente(Guid direccionAcudienteId, DireccionAcudienteForUpdateDto direccionAcudienteForUpdate, bool trackChanges)
    {
        var direccionAcudienteEntity = _repository.DireccionAcudiente.GetDireccionAcudiente(direccionAcudienteId, trackChanges);
        if (direccionAcudienteEntity is null)
            throw new DireccionAcudienteNotFoundException(direccionAcudienteId);
        _mapper.Map(direccionAcudienteForUpdate, direccionAcudienteEntity);
        _repository.Save();
    }
}

