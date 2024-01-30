using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.D_DepartamentoAcademico;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace Service;

internal sealed class MateriaService : IMateriaService
{ 
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public MateriaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<MateriaDto> GetAllMaterias(bool trackChanges)
    {
        var materias = _repository.Materia.GetAllMaterias(trackChanges);

        var materiasDto = _mapper.Map<IEnumerable<MateriaDto>>(materias);

        return materiasDto;
    }

    public MateriaDto GetMateria(Guid id, bool trackChanges)
    {
        var materia = _repository.Materia.GetMateria(id, trackChanges);
        if (materia is null)
            throw new MateriaNotFoundException(id);

        var materiaDto = _mapper.Map<MateriaDto>(materia);
        return materiaDto;
    }

    public MateriaDto CreateMateria(MateriaForCreationDto materia)
    {
        var materiaEntity = _mapper.Map<Materias>(materia);

        _repository.Materia.CreateMateria(materiaEntity);
        _repository.Save();

        var materiaToReturn = _mapper.Map<MateriaDto>(materiaEntity);

        return materiaToReturn;
    }

    public IEnumerable<MateriaDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var materiaEntities = _repository.Materia.GetByIds(ids, trackChanges);
        if (ids.Count() != materiaEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var materiasToReturn = _mapper.Map<IEnumerable<MateriaDto>>(materiaEntities);

        return materiasToReturn;
    }

    public (IEnumerable<MateriaDto> materias, string ids) CreateMateriaCollection
        (IEnumerable<MateriaForCreationDto> materiaCollection)
    {
        if (materiaCollection is null)
            throw new MateriaCollectionBadRequest();

        var materiaEntities = _mapper.Map<IEnumerable<Materias>>(materiaCollection);
        foreach (var materia in materiaEntities)
        {
            _repository.Materia.CreateMateria(materia);
        }

        _repository.Save();

        var materiaCollectionToReturn = _mapper.Map<IEnumerable<MateriaDto>>(materiaEntities);
        var ids = string.Join(",", materiaCollectionToReturn.Select(m => m.MateriaId));

        return (materias: materiaCollectionToReturn, ids: ids);
    }

    public void DeleteMateria(Guid materiaId, bool trackChanges)
    {
        var materia = _repository.Materia.GetMateria(materiaId, trackChanges);
        if (materia is null)
        {
            throw new MateriaNotFoundException(materiaId);
        }

        _repository.Materia.DeleteMateria(materia);
        _repository.Save();
    }

    public void UpdateMateria(Guid materiaId, MateriaForUpdateDto materiaForUpdate, bool trackChanges)
    {
        var materiaEntity = _repository.Materia.GetMateria(materiaId, trackChanges);
        if (materiaEntity is null)
            throw new MateriaNotFoundException(materiaId);
        _mapper.Map(materiaForUpdate, materiaEntity);
        _repository.Save();
    }
}
