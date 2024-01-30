namespace Entities.Exceptions;

public sealed class EstadisticaNotFoundException : NotFoundException
{
    public EstadisticaNotFoundException(int EstadisticaId)
        : base($"The CandidatoEstudiante with id: {EstadisticaId} doesn't exist in the database.")
    {
    }
}