using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class PreMatriculaService : IPreMatriculaService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PreMatriculaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<PreMatriculaDto> GetAllPreMatriculas(bool trackChanges)
        {
            var preMatriculas = _repository.PreMatricula.GetAllPreMatriculas(trackChanges);

            var preMatriculasDto = _mapper.Map<IEnumerable<PreMatriculaDto>>(preMatriculas);

            return preMatriculasDto;
        }

        public PreMatriculaDto GetPreMatricula(Guid id, bool trackChanges)
        {
            var preMatricula = _repository.PreMatricula.GetPreMatricula(id, trackChanges);
            if (preMatricula is null)
                throw new PreMatriculaNotFoundException(id);

            var preMatriculaDto = _mapper.Map<PreMatriculaDto>(preMatricula);
            return preMatriculaDto;
        }

        public PreMatriculaDto CreatePreMatricula(PreMatriculaForCreationDto preMatricula)
        {
            var preMatriculaEntity = _mapper.Map<PreMatricula>(preMatricula);

            _repository.PreMatricula.CreatePreMatricula(preMatriculaEntity);
            _repository.Save();

            var preMatriculaToReturn = _mapper.Map<PreMatriculaDto>(preMatriculaEntity);

            return preMatriculaToReturn;
        }

        public IEnumerable<PreMatriculaDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var preMatriculaEntities = _repository.PreMatricula.GetByIds(ids, trackChanges);
            if (ids.Count() != preMatriculaEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var preMatriculasToReturn = _mapper.Map<IEnumerable<PreMatriculaDto>>(preMatriculaEntities);

            return preMatriculasToReturn;
        }

        public (IEnumerable<PreMatriculaDto> preMatriculas, string ids) CreatePreMatriculaCollection
            (IEnumerable<PreMatriculaForCreationDto> preMatriculaCollection)
        {
            if (preMatriculaCollection is null)
                throw new PreMatriculaCollectionBadRequest();

            var preMatriculaEntities = _mapper.Map<IEnumerable<PreMatricula>>(preMatriculaCollection);
            foreach (var preMatricula in preMatriculaEntities)
            {
                _repository.PreMatricula.CreatePreMatricula(preMatricula);
            }

            _repository.Save();

            var preMatriculaCollectionToReturn = _mapper.Map<IEnumerable<PreMatriculaDto>>(preMatriculaEntities);
            var ids = string.Join(",", preMatriculaCollectionToReturn.Select(c => c.PreMatriculaId));

            return (preMatriculas: preMatriculaCollectionToReturn, ids: ids);
        }
        public void DeletePreMatricula(Guid preMatriculaId, bool trackChanges)
        {
            var preMatricula = _repository.PreMatricula.GetPreMatricula(preMatriculaId, trackChanges);
            if (preMatricula is null)
            {
                throw new PreMatriculaNotFoundException(preMatriculaId);
            }

            _repository.PreMatricula.DeletePreMatricula(preMatricula);
            _repository.Save();
        }
        public void UpdatePreMatricula(Guid preMatriculaId, PreMatriculaForUpdateDto preMatriculaForUpdate, bool trackChanges)
        {
            var preMatriculaEntity = _repository.PreMatricula.GetPreMatricula(preMatriculaId, trackChanges);
            if (preMatriculaEntity is null)
                throw new PreMatriculaNotFoundException(preMatriculaId);
            _mapper.Map(preMatriculaForUpdate, preMatriculaEntity);
            _repository.Save();
        }
    }
}
