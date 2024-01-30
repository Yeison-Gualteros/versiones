namespace Entities.Exceptions;

public sealed class HorarioNotFoundException : NotFoundException
{
    public HorarioNotFoundException(Guid HorarioId)
        : base($"The Horario with id: {HorarioId} doesn't exist in the database.")
    {
    }
}