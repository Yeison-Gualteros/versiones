using Entities.Models.D_Notas;

namespace Contracts;
public interface IEstadisticaRepository
{
    IEnumerable<Estadisticas> GetAllEstadisticas(bool trackChanges);
    Estadisticas GetEstadistica(int estadisticaId, bool trackChanges);
    void CreateEstadistica(Estadisticas estadistica);
    IEnumerable<Estadisticas> GetByIds(IEnumerable<int> ids, bool trackChanges);
    void DeleteEstadistica(Estadisticas estadistica);
}
