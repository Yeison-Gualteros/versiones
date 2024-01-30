namespace Entities.Exceptions;

public sealed class DireccionAcudienteCollectionBadRequest : BadRequestException
{
    public DireccionAcudienteCollectionBadRequest()
        : base("DireccionAcudiente collection sent from a client is null.")
    {
    }
}
