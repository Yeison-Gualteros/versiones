using Contracts;
using Entities.Models.D_DepartamentoAcademico;

namespace Repository;

internal sealed class CursoRepository : RepositoryBase<Cursos>, ICursoRepository
{
    public CursoRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Cursos> GetAllCursos(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.Nivel)
            .ToList();

    public Cursos GetCurso(Guid cursoId, bool trackChanges) =>
        FindByCondition(c => c.CursoId.Equals(cursoId), trackChanges)
        .SingleOrDefault();

    public void CreateCurso(Cursos curso) => Create(curso);

    public IEnumerable<Cursos> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(x => ids.Contains(x.CursoId), trackChanges)
    .ToList();

    public void DeleteCurso(Cursos curso) => Delete(curso);
}
