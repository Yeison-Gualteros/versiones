using Entities.Models.D_Notas;

namespace Contracts;

public interface IAsistenciaRepository
{
    IEnumerable<Asistencia> GetAllAsistencias(bool trackChanges);
    Asistencia GetAsistencia(int asistenciaId, bool trackChanges);
    void CreateAsistencia(Asistencia asistencia);
    IEnumerable<Asistencia> GetByIds(IEnumerable<int> ids, bool trackChanges);
    void DeleteAsistencia(Asistencia asistencia);
}


