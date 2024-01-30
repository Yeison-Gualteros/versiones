using Entities.Models;
using Entities.Models.D_Estudiante;

namespace Contracts
{
    public interface IRespuestaCupoRepository
    {
        IEnumerable<RespuestaCupo> GetAllRespuestaCupos(bool trackChanges);
        RespuestaCupo GetRespuestaCupo(Guid respuestaCupoId, bool trackChanges);
        void CreateRespuestaCupo(RespuestaCupo respuestaCupo);
        IEnumerable<RespuestaCupo> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteRespuestaCupo(RespuestaCupo respuestaCupo);
    }
}
