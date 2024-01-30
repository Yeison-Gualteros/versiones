using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEstudianteDocumentosService
    {
        IEnumerable<EstudianteDocumentosDto> GetAllEstudianteDocumentos(bool trackChanges);
        EstudianteDocumentosDto GetEstudianteDocumentos(Guid estudianteDocumentoId, bool trackChanges);
        EstudianteDocumentosDto CreateEstudianteDocumentos(EstudianteDocumentosForCreationDto estudianteDocumento);
        IEnumerable<EstudianteDocumentosDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<EstudianteDocumentosDto> estudianteDocumentos, string ids) CreateEstudianteDocumentosCollection
            (IEnumerable<EstudianteDocumentosForCreationDto> estudianteDocumentosCollection);
        void DeleteEstudianteDocumentos(Guid estudianteDocumentoId, bool trackChanges);
        void UpdateEstudianteDocumentos(Guid estudianteDocumentoId, EstudianteDocumentosForUpdateDto estudianteDocumentoForUpdate, bool trackChanges);
    }
}

