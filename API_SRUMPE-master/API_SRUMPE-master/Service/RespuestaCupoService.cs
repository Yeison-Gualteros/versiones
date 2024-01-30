using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class RespuestaCupoService : IRespuestaCupoService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public RespuestaCupoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<RespuestaCupoDto> GetAllRespuestaCupos(bool trackChanges)
        {
            var respuestaCupos = _repository.RespuestaCupo.GetAllRespuestaCupos(trackChanges);

            var respuestaCuposDto = _mapper.Map<IEnumerable<RespuestaCupoDto>>(respuestaCupos);

            return respuestaCuposDto;
        }

        public RespuestaCupoDto GetRespuestaCupo(Guid id, bool trackChanges)
        {
            var respuestaCupo = _repository.RespuestaCupo.GetRespuestaCupo(id, trackChanges);
            if (respuestaCupo is null)
                throw new RespuestaCupoNotFoundException(id);

            var respuestaCupoDto = _mapper.Map<RespuestaCupoDto>(respuestaCupo);
            return respuestaCupoDto;
        }

        public RespuestaCupoDto CreateRespuestaCupo(RespuestaCupoForCreationDto respuestaCupo)
        {
            var respuestaCupoEntity = _mapper.Map<RespuestaCupo>(respuestaCupo);

            _repository.RespuestaCupo.CreateRespuestaCupo(respuestaCupoEntity);
            _repository.Save();

            var respuestaCupoToReturn = _mapper.Map<RespuestaCupoDto>(respuestaCupoEntity);

            return respuestaCupoToReturn;
        }

        public IEnumerable<RespuestaCupoDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var respuestaCupoEntities = _repository.RespuestaCupo.GetByIds(ids, trackChanges);
            if (ids.Count() != respuestaCupoEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var respuestaCuposToReturn = _mapper.Map<IEnumerable<RespuestaCupoDto>>(respuestaCupoEntities);

            return respuestaCuposToReturn;
        }

        public (IEnumerable<RespuestaCupoDto> respuestaCupos, string ids) CreateRespuestaCupoCollection
            (IEnumerable<RespuestaCupoForCreationDto> respuestaCupoCollection)
        {
            if (respuestaCupoCollection is null)
                throw new RespuestaCupoCollectionBadRequest();

            var respuestaCupoEntities = _mapper.Map<IEnumerable<RespuestaCupo>>(respuestaCupoCollection);
            foreach (var respuestaCupo in respuestaCupoEntities)
            {
                _repository.RespuestaCupo.CreateRespuestaCupo(respuestaCupo);
            }

            _repository.Save();

            var respuestaCupoCollectionToReturn = _mapper.Map<IEnumerable<RespuestaCupoDto>>(respuestaCupoEntities);
            var ids = string.Join(",", respuestaCupoCollectionToReturn.Select(c => c.RespuestaCupoId));

            return (respuestaCupos: respuestaCupoCollectionToReturn, ids: ids);
        }
        public void DeleteRespuestaCupo(Guid respuestaCupoId, bool trackChanges)
        {
            var respuestaCupo = _repository.RespuestaCupo.GetRespuestaCupo(respuestaCupoId, trackChanges);
            if (respuestaCupo is null)
            {
                throw new RespuestaCupoNotFoundException(respuestaCupoId);
            }

            _repository.RespuestaCupo.DeleteRespuestaCupo(respuestaCupo);
            _repository.Save();

        }
        public void UpdateRespuestaCupo(Guid respuestaCupoId, RespuestaCupoForUpdateDto respuestaCupoForUpdate, bool trackChanges)
        {
            var respuestaCupoEntity = _repository.RespuestaCupo.GetRespuestaCupo(respuestaCupoId, trackChanges);
            if (respuestaCupoEntity is null)
                throw new RespuestaCupoNotFoundException(respuestaCupoId);
            _mapper.Map(respuestaCupoForUpdate, respuestaCupoEntity);
            _repository.Save();
        }
    }
}
