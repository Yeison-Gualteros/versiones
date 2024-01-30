using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface ICursoService
{
    IEnumerable<CursoDto> GetAllCursos(bool trackChanges);
    CursoDto GetCurso(Guid cursoId, bool trackChanges);
    CursoDto CreateCurso(CursoForCreationDto curso);
    IEnumerable<CursoDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<CursoDto> cursos, string ids) CreateCursoCollection(IEnumerable<CursoForCreationDto> cursoCollection);
    void DeleteCurso(Guid cursoId, bool trackChanges);
    void UpdateCurso(Guid cursoId, CursoForUpdateDto cursoForUpdate, bool trackChanges);
}

