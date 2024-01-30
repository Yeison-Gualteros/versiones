using Entities.Models.D_DepartamentoAcademico;

namespace Contracts;
public interface ICursoRepository
{
    IEnumerable<Cursos> GetAllCursos(bool trackChanges);
    Cursos GetCurso(Guid cursoId, bool trackChanges);
    void CreateCurso(Cursos curso);
    IEnumerable<Cursos> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteCurso(Cursos curso);
}
