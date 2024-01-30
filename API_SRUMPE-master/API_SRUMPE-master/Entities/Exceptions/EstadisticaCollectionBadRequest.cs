namespace Entities.Exceptions;

public sealed class EstadisticaCollectionBadRequest : BadRequestException
{
    public EstadisticaCollectionBadRequest()
        : base("Estadistica collection sent from a client is null.")
    {
    }
}
