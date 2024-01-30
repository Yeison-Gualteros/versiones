namespace Entities.Exceptions;

public sealed class HorarioCollectionBadRequest : BadRequestException
{
    public HorarioCollectionBadRequest()
        : base("Horario collection sent from a client is null.")
    {
    }
}