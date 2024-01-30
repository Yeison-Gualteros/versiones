using Contracts;
using Entities.Models.D_Notas;

namespace Repository
{
    internal sealed class EstadisticaRepository : RepositoryBase<Estadisticas>, IEstadisticaRepository
    {
        public EstadisticaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Estadisticas> GetAllEstadisticas(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.AñoEscolar)
                .ToList();

        public Estadisticas GetEstadistica(int estadisticaId, bool trackChanges) =>
            FindByCondition(c => c.EstadisticaId == estadisticaId, trackChanges)
            .SingleOrDefault();

        public void CreateEstadistica(Estadisticas estadistica) => Create(estadistica);

        public IEnumerable<Estadisticas> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.EstadisticaId), trackChanges)
            .ToList();

        public void DeleteEstadistica(Estadisticas estadistica) => Delete(estadistica);
    }
}
