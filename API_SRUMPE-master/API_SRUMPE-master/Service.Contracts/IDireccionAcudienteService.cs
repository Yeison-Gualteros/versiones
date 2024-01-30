using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IDireccionAcudienteService
{
    IEnumerable<DireccionAcudienteDto> GetAllDireccionAcudientes(bool trackChanges);
    DireccionAcudienteDto GetDireccionAcudiente(Guid direccionAcudienteId, bool trackChanges);
    DireccionAcudienteDto CreateDireccionAcudiente(DireccionAcudienteForCreationDto direccionAcudiente);
    IEnumerable<DireccionAcudienteDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<DireccionAcudienteDto> direccionAcudientes, string ids) CreateDireccionAcudienteCollection
        (IEnumerable<DireccionAcudienteForCreationDto> direccionAcudienteCollection);

    void DeleteDireccionAcudiente(Guid direccionAcudienteId, bool trackChanges);

    void UpdateDireccionAcudiente(Guid direccionAcudienteId, DireccionAcudienteForUpdateDto direccionAcudienteForUpdate, bool trackChanges);
}
