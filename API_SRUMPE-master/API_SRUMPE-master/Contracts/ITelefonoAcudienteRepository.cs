using Entities.Models.D_Acudiente;

namespace Contracts;

public interface ITelefonoAcudienteRepository
{
    IEnumerable<TelefonoAcudiente> GetAllTelefonoAcudientes(bool trackChanges);
    TelefonoAcudiente GetTelefonoAcudiente(Guid telefonoAcudienteId, bool trackChanges);
    void CreateTelefonoAcudiente(TelefonoAcudiente telefonoAcudiente);
    IEnumerable<TelefonoAcudiente> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteTelefonoAcudiente(TelefonoAcudiente telefonoAcudiente);
}
