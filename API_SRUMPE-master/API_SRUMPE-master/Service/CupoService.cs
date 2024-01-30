using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.D_Estudiante;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

internal sealed class CupoService : ICupoService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CupoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CupoDto> GetAllCupos(bool trackChanges)
    {
        var cupos = _repository.Cupo.GetAllCupos(trackChanges);

        var cuposDto = _mapper.Map<IEnumerable<CupoDto>>(cupos);

        return cuposDto;
    }

    public CupoDto GetCupo(Guid id, bool trackChanges)
    {
        var cupo = _repository.Cupo.GetCupo(id, trackChanges);
        if (cupo is null)
            throw new CupoNotFoundException(id);

        var cupoDto = _mapper.Map<CupoDto>(cupo);
        return cupoDto;
    }

    public CupoDto CreateCupo(CupoForCreationDto cupo)
    {
        var cupoEntity = _mapper.Map<Cupo>(cupo);

        _repository.Cupo.CreateCupo(cupoEntity);
        _repository.Save();

        var cupoToReturn = _mapper.Map<CupoDto>(cupoEntity);

        return cupoToReturn;
    }

    public IEnumerable<CupoDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var cupoEntities = _repository.Cupo.GetByIds(ids, trackChanges);
        if (ids.Count() != cupoEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var cuposToReturn = _mapper.Map<IEnumerable<CupoDto>>(cupoEntities);

        return cuposToReturn;
    }

    public (IEnumerable<CupoDto> cupos, string ids) CreateCupoCollection
        (IEnumerable<CupoForCreationDto> cupoCollection)
    {
        if (cupoCollection is null)
            throw new CupoCollectionBadRequest();

        var cupoEntities = _mapper.Map<IEnumerable<Cupo>>(cupoCollection);
        foreach (var cupo in cupoEntities)
        {
            _repository.Cupo.CreateCupo(cupo);
        }

        _repository.Save();

        var cupoCollectionToReturn = _mapper.Map<IEnumerable<CupoDto>>(cupoEntities);
        var ids = string.Join(",", cupoCollectionToReturn.Select(c => c.CupoId));

        return (cupos: cupoCollectionToReturn, ids: ids);
    }

    public void DeleteCupo(Guid cupoId, bool trackChanges)
    {
        var cupo = _repository.Cupo.GetCupo(cupoId, trackChanges);
        if (cupo is null)
        {
            throw new CupoNotFoundException(cupoId);
        }

        _repository.Cupo.DeleteCupo(cupo);
        _repository.Save();
    }

    public void UpdateCupo(Guid cupoId, CupoForUpdateDto cupoForUpdate, bool trackChanges)
    {
        var cupoEntity = _repository.Cupo.GetCupo(cupoId, trackChanges);
        if (cupoEntity is null)
            throw new CupoNotFoundException(cupoId);
        _mapper.Map(cupoForUpdate, cupoEntity);
        _repository.Save();
    }
}
