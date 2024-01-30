namespace Entities.Exceptions;

public sealed class MatriculaCollectionBadRequest : BadRequestException
{
    public MatriculaCollectionBadRequest()
        : base("Matricula collection sent from a client is null.")
    {
    }
}