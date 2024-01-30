namespace Entities.Exceptions;

public sealed class PreMatriculaCollectionBadRequest : BadRequestException
{
    public PreMatriculaCollectionBadRequest()
        : base("PreMatricule collection sent from a client is null.")
    {
    }
}
