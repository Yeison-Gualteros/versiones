using Contracts;
using Entities.Models.D_Notas;

namespace Repository;

internal sealed class AsistenciaRepository : RepositoryBase<Asistencia>, IAsistenciaRepository
{
    public AsistenciaRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Asistencia> GetAllAsistencias(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.NombreAsistente)
            .ToList();

    public Asistencia GetAsistencia(int asistenciaId, bool trackChanges) =>
        FindByCondition(c => c.AsistenciaId == asistenciaId, trackChanges)
        .SingleOrDefault();

    public void CreateAsistencia(Asistencia asistencia) => Create(asistencia);

    public IEnumerable<Asistencia> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
        FindByCondition(x => ids.Contains(x.AsistenciaId), trackChanges)
        .ToList();

    public void DeleteAsistencia(Asistencia asistencia) => Delete(asistencia);
}



