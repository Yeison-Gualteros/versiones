using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IAulaService
{
    IEnumerable<AulaDto> GetAllAulas(bool trackChanges);
    AulaDto GetAula(Guid aulaId, bool trackChanges);
    AulaDto CreateAula(AulaForCreationDto aula);
    IEnumerable<AulaDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<AulaDto> aulas, string ids) CreateAulaCollection(IEnumerable<AulaForCreationDto> aulaCollection);
    void DeleteAula(Guid aulaId, bool trackChanges);
    void UpdateAula(Guid aulaId, AulaForUpdateDto aulaForUpdate, bool trackChanges);
}
