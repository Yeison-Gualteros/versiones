using Entities.Models.D_Acudiente;

namespace Contracts;
public interface IDireccionAcudienteRepository
{
    IEnumerable<DireccionAcudiente> GetAllDireccionAcudientes(bool trackChanges);
    DireccionAcudiente GetDireccionAcudiente(Guid direccionAcudienteId, bool trackChanges);
    void CreateDireccionAcudiente(DireccionAcudiente direccionAcudiente);
    IEnumerable<DireccionAcudiente> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteDireccionAcudiente(DireccionAcudiente direccionAcudiente);
}

