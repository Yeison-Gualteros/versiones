using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IRespuestaCupoService
    {
        IEnumerable<RespuestaCupoDto> GetAllRespuestaCupos(bool trackChanges);
        RespuestaCupoDto GetRespuestaCupo(Guid respuestaCupoId, bool trackChanges);
        RespuestaCupoDto CreateRespuestaCupo(RespuestaCupoForCreationDto respuestaCupo);
        IEnumerable<RespuestaCupoDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<RespuestaCupoDto> respuestaCupos, string ids) CreateRespuestaCupoCollection
            (IEnumerable<RespuestaCupoForCreationDto> respuestaCupoCollection);

        void DeleteRespuestaCupo(Guid respuestaCupoId, bool trackChanges);

        void UpdateRespuestaCupo(Guid respuestaCupoId, RespuestaCupoForUpdateDto respuestaCupoForUpdate, bool trackChanges);
    }
}
