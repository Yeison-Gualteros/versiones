using Entities.Models.D_DepartamentoAcademico;

namespace Contracts;

public interface IAulaRepository
{
    IEnumerable<Aulas> GetAllAulas(bool trackChanges);
    Aulas GetAula(Guid aulaId, bool trackChanges);
    void CreateAula(Aulas aula);
    IEnumerable<Aulas> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteAula(Aulas aula);
}
