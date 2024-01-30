using Contracts;
using Entities.Models.D_DepartamentoAcademico;


namespace Repository;

internal sealed class AulaRepository : RepositoryBase<Aulas>, IAulaRepository
{
    public AulaRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Aulas> GetAllAulas(bool trackChanges) =>
        FindAll(trackChanges)
    .OrderBy(a => a.EstadoAula)
            .ToList();

    public Aulas GetAula(Guid aulaId, bool trackChanges) =>
        FindByCondition(a => a.AulaId.Equals(aulaId), trackChanges)
        .SingleOrDefault();
    public void CreateAula(Aulas aula) => Create(aula);

    public IEnumerable<Aulas> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(x => ids.Contains(x.AulaId), trackChanges)
        .ToList();

    public void DeleteAula(Aulas aula) => Delete(aula);
}