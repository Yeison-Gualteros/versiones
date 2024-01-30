using Contracts;
using Entities.Models.D_DepartamentoAcademico;


namespace Repository;

internal sealed class MateriaRepository : RepositoryBase<Materias>, IMateriaRepository
{
    public MateriaRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Materias> GetAllMaterias(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(m => m.Nivel)
            .ToList();

    public Materias GetMateria(Guid materiaId, bool trackChanges) =>
        FindByCondition(m => m.MateriaId.Equals(materiaId), trackChanges)
        .SingleOrDefault();

    public void CreateMateria(Materias materia) => Create(materia);

    public IEnumerable<Materias> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(x => ids.Contains(x.MateriaId), trackChanges)
        .ToList();

    public void DeleteMateria(Materias materia) => Delete(materia);
}
