using Contracts;
using Entities.Models;
using Entities.Models.D_Estudiante;

namespace Repository
{
    internal sealed class PreMatriculaRepository : RepositoryBase<PreMatricula>, IPreMatriculaRepository
    {
        public PreMatriculaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<PreMatricula> GetAllPreMatriculas(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.EstadoPreMatricula)
                .ToList();

        public PreMatricula GetPreMatricula(Guid preMatriculaId, bool trackChanges) =>
            FindByCondition(c => c.PreMatriculaId.Equals(preMatriculaId), trackChanges)
            .SingleOrDefault();

        public void CreatePreMatricula(PreMatricula preMatricula) => Create(preMatricula);

        public IEnumerable<PreMatricula> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.PreMatriculaId), trackChanges)
            .ToList();

        public void DeletePreMatricula(PreMatricula preMatricula) => Delete(preMatricula);
    }
}
