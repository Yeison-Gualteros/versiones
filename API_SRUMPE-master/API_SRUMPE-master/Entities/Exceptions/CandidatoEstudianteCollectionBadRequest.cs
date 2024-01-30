namespace Entities.Exceptions;

public sealed class CandidatoEstudianteCollectionBadRequest : BadRequestException
{
    public CandidatoEstudianteCollectionBadRequest()
        : base("CandidatoEstudiante collection sent from a client is null.")
    {
    }
}
