using Entities.Models.D_Estudiante;

namespace Contracts;

public interface ICupoRepository
{
    IEnumerable<Cupo> GetAllCupos(bool trackChanges);
    Cupo GetCupo(Guid cupoId, bool trackChanges);
    void CreateCupo(Cupo cupo);
    IEnumerable<Cupo> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteCupo(Cupo cupo);
}

