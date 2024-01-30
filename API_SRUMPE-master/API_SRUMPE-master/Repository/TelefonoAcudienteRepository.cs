using Contracts;
using Entities.Models.D_Acudiente;

namespace Repository
{
    internal sealed class TelefonoAcudienteRepository : RepositoryBase<TelefonoAcudiente>, ITelefonoAcudienteRepository
    {
        public TelefonoAcudienteRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<TelefonoAcudiente> GetAllTelefonoAcudientes(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.Numero)
                .ToList();

        public TelefonoAcudiente GetTelefonoAcudiente(Guid telefonoAcudienteId, bool trackChanges) =>
            FindByCondition(c => c.TelefonoAcudienteId.Equals(telefonoAcudienteId), trackChanges)
            .SingleOrDefault();

        public void CreateTelefonoAcudiente(TelefonoAcudiente telefonoAcudiente) => Create(telefonoAcudiente);

        public IEnumerable<TelefonoAcudiente> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.TelefonoAcudienteId), trackChanges)
            .ToList();

        public void DeleteTelefonoAcudiente(TelefonoAcudiente telefonoAcudiente) => Delete(telefonoAcudiente);
    }
}
