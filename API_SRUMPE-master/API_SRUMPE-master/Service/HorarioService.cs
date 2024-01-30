using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.D_DepartamentoAcademico;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;
internal sealed class HorarioService : IHorarioService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public HorarioService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<HorarioDto> GetAllHorarios(bool trackChanges)
    {
        var horario = _repository.Horario.GetAllHorarios(trackChanges);

        var horarioDto = _mapper.Map<IEnumerable<HorarioDto>>(horario);

        return horarioDto;
    }

    public HorarioDto GetHorario(Guid id, bool trackChanges)
    {
        var horario = _repository.Horario.GetHorario(id, trackChanges);
        if (horario is null)
            throw new HorarioNotFoundException(id);

        var horarioDto = _mapper.Map<HorarioDto>(horario);
        return horarioDto;
    }

    public HorarioDto CreateHorario(HorarioForCreationDto horario)
    {
        var horarioEntity = _mapper.Map<Horarios>(horario);

        _repository.Horario.CreateHorario(horarioEntity);
        _repository.Save();

        var horarioToReturn = _mapper.Map<HorarioDto>(horarioEntity);

        return horarioToReturn;
    }

    public IEnumerable<HorarioDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var horarioEntities = _repository.Horario.GetByIds(ids, trackChanges);
        if (ids.Count() != horarioEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var horariosToReturn = _mapper.Map<IEnumerable<HorarioDto>>(horarioEntities);

        return horariosToReturn;
    }

    public (IEnumerable<HorarioDto> horarios, string ids) CreateHorarioCollection
        (IEnumerable<HorarioForCreationDto> horarioCollection)
    {
        if (horarioCollection is null)
            throw new HorarioCollectionBadRequest();

        var horarioEntities = _mapper.Map<IEnumerable<Horarios>>(horarioCollection);
        foreach (var horario in horarioEntities)
        {
            _repository.Horario.CreateHorario(horario);
        }

        _repository.Save();

        var horarioCollectionToReturn = _mapper.Map<IEnumerable<HorarioDto>>(horarioEntities);
        var ids = string.Join(",", horarioCollectionToReturn.Select(h => h.HorarioId));

        return (horarios: horarioCollectionToReturn, ids: ids);
    }
    public void DeleteHorario(Guid horarioId, bool trackChanges)
    {
        var horario = _repository.Horario.GetHorario(horarioId, trackChanges);
        if (horario is null)
        {
            throw new HorarioNotFoundException(horarioId);
        }

        _repository.Horario.DeleteHorario(horario);
        _repository.Save();

    }
    public void UpdateHorario(Guid horarioId, HorarioForUpdateDto horarioForUpdate, bool trackChanges)
    {
        var horarioEntity = _repository.Horario.GetHorario(horarioId, trackChanges);
        if (horarioEntity is null)
            throw new HorarioNotFoundException(horarioId);
        _mapper.Map(horarioForUpdate, horarioEntity);
        _repository.Save();
    }
}
