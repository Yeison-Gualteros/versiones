using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IAcudienteService
{
    IEnumerable<AcudienteDto> GetAllAcudiente(bool trackChanges);
    AcudienteDto GetAcudiente(Guid acudienteId, bool trackChanges);
    AcudienteDto CreateAcudiente(AcudienteForCreationDto acudiente);
    IEnumerable<AcudienteDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<AcudienteDto> acudiente, string ids) CreateAcudienteCollection
        (IEnumerable<AcudienteForCreationDto> acudienteCollection);
    void DeleteAcudiente(Guid acudienteId, bool trackChanges);
    void UpdateAcudiente(Guid acudienteId, AcudienteForUpdateDto acudienteForUpdate, bool trackChanges);

}
