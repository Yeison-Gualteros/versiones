using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.D_Estudiante;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;
internal sealed class EstudianteDocumentosService : IEstudianteDocumentosService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public EstudianteDocumentosService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<EstudianteDocumentosDto> GetAllEstudianteDocumentos(bool trackChanges)
    {
        var estudianteDocumentos = _repository.EstudianteDocumentos.GetAllEstudianteDocumentos(trackChanges);

        var estudianteDocumentosDto = _mapper.Map<IEnumerable<EstudianteDocumentosDto>>(estudianteDocumentos);

        return estudianteDocumentosDto;
    }

    public EstudianteDocumentosDto GetEstudianteDocumentos(Guid id, bool trackChanges)
    {
        var estudianteDocumento = _repository.EstudianteDocumentos.GetEstudianteDocumentos(id, trackChanges);
        if (estudianteDocumento is null)
            throw new EstudianteDocumentosNotFoundException(id);

        var estudianteDocumentoDto = _mapper.Map<EstudianteDocumentosDto>(estudianteDocumento);
        return estudianteDocumentoDto;
    }

    public EstudianteDocumentosDto CreateEstudianteDocumentos(EstudianteDocumentosForCreationDto estudianteDocumento)
    {
        var estudianteDocumentoEntity = _mapper.Map<EstudianteDocumentos>(estudianteDocumento);

        _repository.EstudianteDocumentos.CreateEstudianteDocumentos(estudianteDocumentoEntity);
        _repository.Save();

        var estudianteDocumentoToReturn = _mapper.Map<EstudianteDocumentosDto>(estudianteDocumentoEntity);

        return estudianteDocumentoToReturn;
    }

    public IEnumerable<EstudianteDocumentosDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var estudianteDocumentoEntities = _repository.EstudianteDocumentos.GetByIds(ids, trackChanges);
        if (ids.Count() != estudianteDocumentoEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var estudianteDocumentosToReturn = _mapper.Map<IEnumerable<EstudianteDocumentosDto>>(estudianteDocumentoEntities);

        return estudianteDocumentosToReturn;
    }

    public (IEnumerable<EstudianteDocumentosDto> estudianteDocumentos, string ids) CreateEstudianteDocumentosCollection
        (IEnumerable<EstudianteDocumentosForCreationDto> estudianteDocumentosCollection)
    {
        if (estudianteDocumentosCollection is null)
            throw new EstudianteDocumentosCollectionBadRequest();

        var estudianteDocumentoEntities = _mapper.Map<IEnumerable<EstudianteDocumentos>>(estudianteDocumentosCollection);
        foreach (var estudianteDocumento in estudianteDocumentoEntities)
        {
            _repository.EstudianteDocumentos.CreateEstudianteDocumentos(estudianteDocumento);
        }

        _repository.Save();

        var estudianteDocumentoCollectionToReturn = _mapper.Map<IEnumerable<EstudianteDocumentosDto>>(estudianteDocumentoEntities);
        var ids = string.Join(",", estudianteDocumentoCollectionToReturn.Select(e => e.EstudianteDocumentosId));

        return (estudianteDocumentos: estudianteDocumentoCollectionToReturn, ids: ids);
    }

    public void DeleteEstudianteDocumentos(Guid estudianteDocumentoId, bool trackChanges)
    {
        var estudianteDocumento = _repository.EstudianteDocumentos.GetEstudianteDocumentos(estudianteDocumentoId, trackChanges);
        if (estudianteDocumento is null)
        {
            throw new EstudianteDocumentosNotFoundException(estudianteDocumentoId);
        }

        _repository.EstudianteDocumentos.DeleteEstudianteDocumentos(estudianteDocumento);
        _repository.Save();
    }

    public void UpdateEstudianteDocumentos(Guid estudianteDocumentoId, EstudianteDocumentosForUpdateDto estudianteDocumentoForUpdate, bool trackChanges)
    {
        var estudianteDocumentoEntity = _repository.EstudianteDocumentos.GetEstudianteDocumentos(estudianteDocumentoId, trackChanges);
        if (estudianteDocumentoEntity is null)
            throw new EstudianteDocumentosNotFoundException(estudianteDocumentoId);
        _mapper.Map(estudianteDocumentoForUpdate, estudianteDocumentoEntity);
        _repository.Save();
    }
}



