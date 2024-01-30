using Entities.Models.D_DepartamentoAcademico;

namespace Contracts;

public interface IHorarioRepository
{
    IEnumerable<Horarios> GetAllHorarios(bool trackChanges);
    Horarios GetHorario(Guid horarioId, bool trackChanges);
    void CreateHorario(Horarios horario);
    IEnumerable<Horarios> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteHorario(Horarios horario);
}
