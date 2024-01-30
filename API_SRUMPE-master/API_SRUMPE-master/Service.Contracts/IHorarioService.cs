using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IHorarioService
{
    IEnumerable<HorarioDto> GetAllHorarios(bool trackChanges);
    HorarioDto GetHorario(Guid horarioId, bool trackChanges);
    HorarioDto CreateHorario(HorarioForCreationDto horario);
    IEnumerable<HorarioDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<HorarioDto> horarios, string ids) CreateHorarioCollection(IEnumerable<HorarioForCreationDto> horarioCollection);
    void DeleteHorario(Guid horarioId, bool trackChanges);
    void UpdateHorario(Guid horarioId, HorarioForUpdateDto horarioForUpdate, bool trackChanges);
}
