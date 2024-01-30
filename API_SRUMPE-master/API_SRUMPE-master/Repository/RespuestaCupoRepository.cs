using Contracts;
using Entities.Models;
using Entities.Models.D_Estudiante;

namespace Repository
{
    internal sealed class RespuestaCupoRepository : RepositoryBase<RespuestaCupo>, IRespuestaCupoRepository
    {
        public RespuestaCupoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<RespuestaCupo> GetAllRespuestaCupos(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.EstadoRespuesta)
                .ToList();

        public RespuestaCupo GetRespuestaCupo(Guid respuestaCupoId, bool trackChanges) =>
            FindByCondition(c => c.RespuestaCupoId.Equals(respuestaCupoId), trackChanges)
            .SingleOrDefault();

        public void CreateRespuestaCupo(RespuestaCupo respuestaCupo) => Create(respuestaCupo);

        public IEnumerable<RespuestaCupo> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.RespuestaCupoId), trackChanges)
        .ToList();

        public void DeleteRespuestaCupo(RespuestaCupo respuestaCupo) => Delete(respuestaCupo);
    }
}
