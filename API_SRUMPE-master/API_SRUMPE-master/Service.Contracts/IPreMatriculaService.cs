using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPreMatriculaService
    {
        IEnumerable<PreMatriculaDto> GetAllPreMatriculas(bool trackChanges);
        PreMatriculaDto GetPreMatricula(Guid preMatriculaId, bool trackChanges);
        PreMatriculaDto CreatePreMatricula(PreMatriculaForCreationDto preMatricula);
        IEnumerable<PreMatriculaDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<PreMatriculaDto> preMatriculas, string ids) CreatePreMatriculaCollection(IEnumerable<PreMatriculaForCreationDto> preMatriculaCollection);
        void DeletePreMatricula(Guid preMatriculaId, bool trackChanges);
        void UpdatePreMatricula(Guid preMatriculaId, PreMatriculaForUpdateDto preMatriculaForUpdate, bool trackChanges);
    }
}
