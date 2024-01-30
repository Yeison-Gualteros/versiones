using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IEstadisticaService
{
    IEnumerable<EstadisticaDto> GetAllEstadisticas(bool trackChanges);
    EstadisticaDto GetEstadistica(int estadisticaId, bool trackChanges);
    EstadisticaDto CreateEstadistica(EstadisticaForCreationDto estadistica);
    IEnumerable<EstadisticaDto> GetByIds(IEnumerable<int> ids, bool trackChanges);
    (IEnumerable<EstadisticaDto> estadistica, string ids) CreateEstadisticaCollection
        (IEnumerable<EstadisticaForCreationDto> estadisticaCollection);
    void DeleteEstadistica(int estadisticaId, bool trackChanges);
    void UpdateEstadistica(int estadisticaId, EstadisticaForUpdateDto estadisticaForUpdate, bool trackChanges);
}
