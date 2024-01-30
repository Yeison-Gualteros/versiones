using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.D_Notas;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class EstadisticaService : IEstadisticaService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public EstadisticaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<EstadisticaDto> GetAllEstadisticas(bool trackChanges)
    {
        var estadisticas = _repository.Estadistica.GetAllEstadisticas(trackChanges);

        var estadisticasDto = _mapper.Map<IEnumerable<EstadisticaDto>>(estadisticas);

        return estadisticasDto;
    }

    public EstadisticaDto GetEstadistica(int id, bool trackChanges)
    {
        var estadistica = _repository.Estadistica.GetEstadistica(id, trackChanges);
        if (estadistica is null)
            throw new EstadisticaNotFoundException(id);

        var estadisticaDto = _mapper.Map<EstadisticaDto>(estadistica);
        return estadisticaDto;
    }

    public EstadisticaDto CreateEstadistica(EstadisticaForCreationDto estadistica)
    {
        var estadisticaEntity = _mapper.Map<Estadisticas>(estadistica);

        _repository.Estadistica.CreateEstadistica(estadisticaEntity);
        _repository.Save();

        var estadisticaToReturn = _mapper.Map<EstadisticaDto>(estadisticaEntity);

        return estadisticaToReturn;
    }

    public IEnumerable<EstadisticaDto> GetByIds(IEnumerable<int> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var estadisticaEntities = _repository.Estadistica.GetByIds(ids, trackChanges);
        if (ids.Count() != estadisticaEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var estadisticasToReturn = _mapper.Map<IEnumerable<EstadisticaDto>>(estadisticaEntities);

        return estadisticasToReturn;
    }

    public void DeleteEstadistica(int estadisticaId, bool trackChanges)
    {
        var estadistica = _repository.Estadistica.GetEstadistica(estadisticaId, trackChanges);
        if (estadistica is null)
        {
            throw new EstadisticaNotFoundException(estadisticaId);
        }

        _repository.Estadistica.DeleteEstadistica(estadistica);
        _repository.Save();
    }

    public void UpdateEstadistica(int estadisticaId, EstadisticaForUpdateDto estadisticaForUpdate, bool trackChanges)
    {
        var estadisticaEntity = _repository.Estadistica.GetEstadistica(estadisticaId, trackChanges);
        if (estadisticaEntity is null)
            throw new EstadisticaNotFoundException(estadisticaId);
        _mapper.Map(estadisticaForUpdate, estadisticaEntity);
        _repository.Save();
    }

    public (IEnumerable<EstadisticaDto> estadistica, string ids) CreateEstadisticaCollection(IEnumerable<EstadisticaForCreationDto> estadisticaCollection)
    {
        if (estadisticaCollection is null)
            throw new EstadisticaCollectionBadRequest();

        var estadisticaEntities = _mapper.Map<IEnumerable<Estadisticas>>(estadisticaCollection);
        foreach (var estadistica in estadisticaEntities)
        {
            _repository.Estadistica.CreateEstadistica(estadistica);
        }

        _repository.Save();

        var estadisticaCollectionToReturn = _mapper.Map<IEnumerable<EstadisticaDto>>(estadisticaEntities);
        var ids = string.Join(",", estadisticaCollectionToReturn.Select(c => c.EstadisticaId));

        return (estadisticas: estadisticaCollectionToReturn, ids: ids);
    }
}
