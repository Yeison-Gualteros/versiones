namespace Entities.Exceptions;

public sealed class CursoCollectionBadRequest : BadRequestException
{
    public CursoCollectionBadRequest()
        : base("Curso collection sent from a client is null.")
    {
    }
}