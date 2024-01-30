using Entities.Models.D_Acudiente;

namespace Contracts;

public interface IAcudienteRepository
{
    IEnumerable<Acudiente> GetAllAcudientes(bool trackChanges);
    Acudiente GetAcudiente(Guid acudienteId, bool trackChanges);
    void CreateAcudiente(Acudiente acudiente);
    IEnumerable<Acudiente> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteAcudiente(Acudiente acudiente);

}
