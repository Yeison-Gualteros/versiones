namespace Entities.Exceptions;

public sealed class AulaCollectionBadRequest : BadRequestException
{
    public AulaCollectionBadRequest()
        : base("Aula collection sent from a client is null.")
    {
    }
}
