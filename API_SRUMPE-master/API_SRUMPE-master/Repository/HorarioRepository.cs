using Contracts;
using Entities.Models.D_DepartamentoAcademico;


namespace Repository;

internal sealed class HorarioRepository : RepositoryBase<Horarios>, IHorarioRepository
{
    public HorarioRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Horarios> GetAllHorarios(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(h => h.PeriodoAcademico)
            .ToList();

    public Horarios GetHorario(Guid horarioId, bool trackChanges) =>
        FindByCondition(h => h.HorarioId.Equals(horarioId), trackChanges)
        .SingleOrDefault();

    public void CreateHorario(Horarios horario) => Create(horario);

    public IEnumerable<Horarios> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(x => ids.Contains(x.HorarioId), trackChanges)
    .ToList();

    public void DeleteHorario(Horarios horario) => Delete(horario);
}

