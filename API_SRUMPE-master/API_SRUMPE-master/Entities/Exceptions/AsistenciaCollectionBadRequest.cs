namespace Entities.Exceptions;

public sealed class AsistenciaCollectionBadRequest : BadRequestException
{
    public AsistenciaCollectionBadRequest()
        : base("Asitencia collection sent from a client is null.")
    {
    }
}
