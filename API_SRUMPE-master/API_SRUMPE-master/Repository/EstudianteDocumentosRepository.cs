using Contracts;
using Entities.Models.D_Estudiante;

namespace Repository;

internal sealed class EstudianteDocumentosRepository : RepositoryBase<EstudianteDocumentos>, IEstudianteDocumentosRepository
{
    public EstudianteDocumentosRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<EstudianteDocumentos> GetAllEstudianteDocumentos(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.NumeroDocumento)
            .ToList();

    public EstudianteDocumentos GetEstudianteDocumentos(Guid estudianteDocumentoId, bool trackChanges) =>
        FindByCondition(c => c.EstudianteDocumentosId.Equals(estudianteDocumentoId), trackChanges)
        .SingleOrDefault();

    public void CreateEstudianteDocumentos(EstudianteDocumentos estudianteDocumento) => Create(estudianteDocumento);

    public IEnumerable<EstudianteDocumentos> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(x => ids.Contains(x.EstudianteDocumentosId), trackChanges)
        .ToList();

    public void DeleteEstudianteDocumentos(EstudianteDocumentos estudianteDocumento) => Delete(estudianteDocumento);
}
