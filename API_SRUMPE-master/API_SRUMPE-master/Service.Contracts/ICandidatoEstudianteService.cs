using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICandidatoEstudianteService
{
    IEnumerable<CandidatoEstudianteDto> GetAllCandidatoEstudiantes(bool trackChanges);
    CandidatoEstudianteDto GetCandidatoEstudiante(Guid candidatoEstudianteId, bool trackChanges);
    CandidatoEstudianteDto CreateCandidatoEstudiante(CandidatoEstudianteForCreationDto candidatoEstudiante);
    IEnumerable<CandidatoEstudianteDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<CandidatoEstudianteDto> candidatoEstudiantes, string ids) CreateCandidatoEstudianteCollection
        (IEnumerable<CandidatoEstudianteForCreationDto> candidatoEstudianteCollection);

    void DeleteCandidatoEstudiante(Guid candidatoEstudianteId, bool trackChanges);

    void UpdateCandidatoEstudiante(Guid candidatoEstudianteId, CandidatoEstudianteForUpdateDto candidatoEstudianteForUpdate, bool trackChanges);
}
