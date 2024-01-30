namespace Entities.Exceptions;

public sealed class CupoNotFoundException : NotFoundException
{
    public CupoNotFoundException(Guid CupoId)
        : base($"The Cupo with id: {CupoId} doesn't exist in the database.")
    {
    }
}

