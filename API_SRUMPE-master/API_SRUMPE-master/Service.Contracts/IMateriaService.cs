using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IMateriaService
{
    IEnumerable<MateriaDto> GetAllMaterias(bool trackChanges);
    MateriaDto GetMateria(Guid materiaId, bool trackChanges);
    MateriaDto CreateMateria(MateriaForCreationDto materia);
    IEnumerable<MateriaDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<MateriaDto> materias, string ids) CreateMateriaCollection
        (IEnumerable<MateriaForCreationDto> materiaCollection);

    void DeleteMateria(Guid materiaId, bool trackChanges);

    void UpdateMateria(Guid materiaId, MateriaForUpdateDto materiaForUpdate, bool trackChanges);
}
