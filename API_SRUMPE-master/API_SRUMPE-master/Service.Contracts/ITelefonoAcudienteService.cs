using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ITelefonoAcudienteService
    {
        IEnumerable<TelefonoAcudienteDto> GetAllTelefonoAcudientes(bool trackChanges);
        TelefonoAcudienteDto GetTelefonoAcudiente(Guid telefonoAcudienteId, bool trackChanges);
        TelefonoAcudienteDto CreateTelefonoAcudiente(TelefonoAcudienteForCreationDto telefonoAcudiente);
        IEnumerable<TelefonoAcudienteDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<TelefonoAcudienteDto> telefonoAcudientes, string ids) CreateTelefonoAcudienteCollection
            (IEnumerable<TelefonoAcudienteForCreationDto> telefonoAcudienteCollection);
        void DeleteTelefonoAcudiente(Guid telefonoAcudienteId, bool trackChanges);
        void UpdateTelefonoAcudiente(Guid telefonoAcudienteId, TelefonoAcudienteForUpdateDto telefonoAcudienteForUpdate, bool trackChanges);
    }
}
