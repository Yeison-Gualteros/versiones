namespace Entities.Exceptions;

public sealed class AulaNotFoundException : NotFoundException
{
    public AulaNotFoundException(Guid AulaId)
        : base($"The Aula with id: {AulaId} doesn't exist in the database.")
    {
    }
}
