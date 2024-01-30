using Contracts;
using Entities.Models.D_DepartamentoAcademico;
using Entities.Models.D_Estudiante;
using Repository.Configuration;

namespace Repository;

internal sealed class CandidatoEstudianteRepository : RepositoryBase<CandidatoEstudiante>, ICandidatoEstudianteRepository
{
    public CandidatoEstudianteRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<CandidatoEstudiante> GetAllCandidatoEstudiantes(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.Nombre)
            .ToList();

    public CandidatoEstudiante GetCandidatoEstudiante(Guid candidatoEstudianteId, bool trackChanges) =>
        FindByCondition(c => c.CandidatoEstudianteId.Equals(candidatoEstudianteId), trackChanges)
        .SingleOrDefault();

    public void CreateCandidatoEstudiante(CandidatoEstudiante candidatoEstudiante) => Create(candidatoEstudiante);

    public IEnumerable<CandidatoEstudiante> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(x => ids.Contains(x.CandidatoEstudianteId), trackChanges)
    .ToList();

    public void DeleteCandidatoEstudiante(CandidatoEstudiante candidatoEstudiante) => Delete(candidatoEstudiante);
}




