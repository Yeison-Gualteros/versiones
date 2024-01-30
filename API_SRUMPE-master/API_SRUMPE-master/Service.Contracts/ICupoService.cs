using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICupoService
{
    IEnumerable<CupoDto> GetAllCupos(bool trackChanges);
    CupoDto GetCupo(Guid cupoId, bool trackChanges);
    CupoDto CreateCupo(CupoForCreationDto cupo);
    IEnumerable<CupoDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<CupoDto> cupos, string ids) CreateCupoCollection
        (IEnumerable<CupoForCreationDto> cupoCollection);
    void DeleteCupo(Guid cupoId, bool trackChanges);
    void UpdateCupo(Guid cupoId, CupoForUpdateDto cupoForUpdate, bool trackChanges);
}