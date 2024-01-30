namespace Entities.Exceptions;

public sealed class CupoCollectionBadRequest : BadRequestException
{
    public CupoCollectionBadRequest()
        : base("Cupo collection sent from a client is null.")
    {
    }
}
