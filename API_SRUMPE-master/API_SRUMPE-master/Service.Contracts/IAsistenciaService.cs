using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IAsistenciaService
{
    IEnumerable<AsistenciaDto> GetAllAsistencia(bool trackChanges);
    AsistenciaDto GetAsistencia(int asistenciaId, bool trackChanges);
    AsistenciaDto CreateAsistencia(AsistenciaForCreationDto asistencia);
    IEnumerable<AsistenciaDto> GetByIds(IEnumerable<int> ids, bool trackChanges);
    (IEnumerable<AsistenciaDto> asistencia, string ids) CreateAsistenciaCollection
        (IEnumerable<AsistenciaForCreationDto> asistenciaCollection);

    void DeleteAsistencia(int asistenciaId, bool trackChanges);
    void UpdateAsistencia(int asistenciaId, AsistenciaForUpdateDto asistenciaForUpdate, bool trackChanges);
}
