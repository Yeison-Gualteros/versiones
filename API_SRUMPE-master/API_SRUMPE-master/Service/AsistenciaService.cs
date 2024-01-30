using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.D_Notas;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;
internal sealed class AsistenciaService : IAsistenciaService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public AsistenciaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<AsistenciaDto> GetAllAsistencia(bool trackChanges)
    {
        var asistencias = _repository.Asistencia.GetAllAsistencias(trackChanges);

        var asistenciasDto = _mapper.Map<IEnumerable<AsistenciaDto>>(asistencias);

        return asistenciasDto;
    }

    public AsistenciaDto GetAsistencia(int id, bool trackChanges)
    {
        var asistencia = _repository.Asistencia.GetAsistencia(id, trackChanges);
        if (asistencia is null)
            throw new AsistenciaNotFoundException(id);

        var asistenciaDto = _mapper.Map<AsistenciaDto>(asistencia);
        return asistenciaDto;
    }

    public AsistenciaDto CreateAsistencia(AsistenciaForCreationDto asistencia)
    {
        var asistenciaEntity = _mapper.Map<Asistencia>(asistencia);

        _repository.Asistencia.CreateAsistencia(asistenciaEntity);
        _repository.Save();

        var asistenciaToReturn = _mapper.Map<AsistenciaDto>(asistenciaEntity);

        return asistenciaToReturn;
    }

    public IEnumerable<AsistenciaDto> GetByIds(IEnumerable<int> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var asistenciaEntities = _repository.Asistencia.GetByIds(ids, trackChanges);
        if (ids.Count() != asistenciaEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var asistenciasToReturn = _mapper.Map<IEnumerable<AsistenciaDto>>(asistenciaEntities);

        return asistenciasToReturn;
    }

    public void DeleteAsistencia(int asistenciaId, bool trackChanges)
    {
        var asistencia = _repository.Asistencia.GetAsistencia(asistenciaId, trackChanges);
        if (asistencia is null)
        {
            throw new AsistenciaNotFoundException(asistenciaId);
        }

        _repository.Asistencia.DeleteAsistencia(asistencia);
        _repository.Save();
    }

    public void UpdateAsistencia(int asistenciaId, AsistenciaForUpdateDto asistenciaForUpdate, bool trackChanges)
    {
        var asistenciaEntity = _repository.Asistencia.GetAsistencia(asistenciaId, trackChanges);
        if (asistenciaEntity is null)
            throw new AsistenciaNotFoundException(asistenciaId);
        _mapper.Map(asistenciaForUpdate, asistenciaEntity);
        _repository.Save();
    }

    public (IEnumerable<AsistenciaDto> asistencia, string ids) CreateAsistenciaCollection(IEnumerable<AsistenciaForCreationDto> asistenciaCollection)
    {
        if (asistenciaCollection is null)
            throw new AsistenciaCollectionBadRequest();

        var asistenciaEntities = _mapper.Map<IEnumerable<Asistencia>>(asistenciaCollection);
        foreach (var asistencia in asistenciaEntities)
        {
            _repository.Asistencia.CreateAsistencia(asistencia);
        }

        _repository.Save();

        var asistenciaCollectionToReturn = _mapper.Map<IEnumerable<AsistenciaDto>>(asistenciaEntities);
        var ids = string.Join(",", asistenciaCollectionToReturn.Select(c => c.AsistenciaId));

        return (asistencias: asistenciaCollectionToReturn, ids: ids);
    }
}
