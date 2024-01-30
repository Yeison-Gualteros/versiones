namespace Entities.Exceptions;

public sealed class AcudienteCollectionBadRequest : BadRequestException
{
    public AcudienteCollectionBadRequest()
        : base("Acudiente collection sent from a client is null.")
    {
    }
}
