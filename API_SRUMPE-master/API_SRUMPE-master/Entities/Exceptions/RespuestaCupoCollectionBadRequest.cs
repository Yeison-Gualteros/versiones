namespace Entities.Exceptions;

public sealed class RespuestaCupoCollectionBadRequest : BadRequestException
{
    public RespuestaCupoCollectionBadRequest()
        : base("RespuestaCupo collection sent from a client is null.")
    {
    }
}
