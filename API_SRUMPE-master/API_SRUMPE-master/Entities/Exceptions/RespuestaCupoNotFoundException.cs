namespace Entities.Exceptions;

public sealed class RespuestaCupoNotFoundException : NotFoundException
{
    public RespuestaCupoNotFoundException(Guid RespuestaCupoId)
        : base($"The RespuestaCupo with id: {RespuestaCupoId} doesn't exist in the database.")
    {
    }
}