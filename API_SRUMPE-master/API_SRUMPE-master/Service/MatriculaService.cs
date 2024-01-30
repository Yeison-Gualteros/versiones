using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class MatriculaService : IMatriculaService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MatriculaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<MatriculaDto> GetAllMatriculas(bool trackChanges)
        {
            var matriculas = _repository.Matricula.GetAllMatriculas(trackChanges);

            var matriculasDto = _mapper.Map<IEnumerable<MatriculaDto>>(matriculas);

            return matriculasDto;
        }

        public MatriculaDto GetMatricula(Guid id, bool trackChanges)
        {
            var matricula = _repository.Matricula.GetMatricula(id, trackChanges);
            if (matricula is null)
                throw new MatriculaNotFoundException(id);

            var matriculaDto = _mapper.Map<MatriculaDto>(matricula);
            return matriculaDto;
        }

        public MatriculaDto CreateMatricula(MatriculaForCreationDto matricula)
        {
            var matriculaEntity = _mapper.Map<Matricula>(matricula);

            _repository.Matricula.CreateMatricula(matriculaEntity);
            _repository.Save();

            var matriculaToReturn = _mapper.Map<MatriculaDto>(matriculaEntity);

            return matriculaToReturn;
        }

        public IEnumerable<MatriculaDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var matriculaEntities = _repository.Matricula.GetByIds(ids, trackChanges);
            if (ids.Count() != matriculaEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var matriculasToReturn = _mapper.Map<IEnumerable<MatriculaDto>>(matriculaEntities);

            return matriculasToReturn;
        }

        public (IEnumerable<MatriculaDto> matriculas, string ids) CreateMatriculaCollection
            (IEnumerable<MatriculaForCreationDto> matriculaCollection)
        {
            if (matriculaCollection is null)
                throw new MatriculaCollectionBadRequest();

            var matriculaEntities = _mapper.Map<IEnumerable<Matricula>>(matriculaCollection);
            foreach (var matricula in matriculaEntities)
            {
                _repository.Matricula.CreateMatricula(matricula);
            }

            _repository.Save();

            var matriculaCollectionToReturn = _mapper.Map<IEnumerable<MatriculaDto>>(matriculaEntities);
            var ids = string.Join(",", matriculaCollectionToReturn.Select(m => m.MatriculaId));

            return (matriculas: matriculaCollectionToReturn, ids: ids);
        }

        public void DeleteMatricula(Guid matriculaId, bool trackChanges)
        {
            var matricula = _repository.Matricula.GetMatricula(matriculaId, trackChanges);
            if (matricula is null)
            {
                throw new MatriculaNotFoundException(matriculaId);
            }

            _repository.Matricula.DeleteMatricula(matricula);
            _repository.Save();
        }

        public void UpdateMatricula(Guid matriculaId, MatriculaForUpdateDto matriculaForUpdate, bool trackChanges)
        {
            var matriculaEntity = _repository.Matricula.GetMatricula(matriculaId, trackChanges);
            if (matriculaEntity is null)
                throw new MatriculaNotFoundException(matriculaId);
            _mapper.Map(matriculaForUpdate, matriculaEntity);
            _repository.Save();
        }
    }
}
