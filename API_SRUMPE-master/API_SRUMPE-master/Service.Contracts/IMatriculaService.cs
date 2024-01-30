using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IMatriculaService
    {
        IEnumerable<MatriculaDto> GetAllMatriculas(bool trackChanges);
        MatriculaDto GetMatricula(Guid matriculaId, bool trackChanges);
        MatriculaDto CreateMatricula(MatriculaForCreationDto matricula);
        IEnumerable<MatriculaDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<MatriculaDto> matriculas, string ids) CreateMatriculaCollection
            (IEnumerable<MatriculaForCreationDto> matriculaCollection);

        void DeleteMatricula(Guid matriculaId, bool trackChanges);

        void UpdateMatricula(Guid matriculaId, MatriculaForUpdateDto matriculaForUpdate, bool trackChanges);
    }
}
