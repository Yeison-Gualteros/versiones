namespace Entities.Exceptions
{
    public sealed class EstudianteDocumentosCollectionBadRequest : BadRequestException
    {
        public EstudianteDocumentosCollectionBadRequest()
            : base("EstudianteDocumentos collection sent from a client is null.")
        {
        }
    }
}
