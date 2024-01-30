using Contracts;
using Entities.Models;
using Entities.Models.D_Estudiante;

namespace Repository
{
    internal sealed class MatriculaRepository : RepositoryBase<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Matricula> GetAllMatriculas(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.EstadoMatricula)
                .ToList();

        public Matricula GetMatricula(Guid matriculaId, bool trackChanges) =>
            FindByCondition(c => c.MatriculaId.Equals(matriculaId), trackChanges)
            .SingleOrDefault();

        public void CreateMatricula(Matricula matricula) => Create(matricula);

        public IEnumerable<Matricula> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.MatriculaId), trackChanges)
        .ToList();

        public void DeleteMatricula(Matricula matricula) => Delete(matricula);
    }
}
