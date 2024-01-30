namespace Entities.Exceptions;

public sealed class CandidatoEstudianteNotFoundException : NotFoundException
{
    public CandidatoEstudianteNotFoundException(Guid EstudianteId)
        : base($"The CandidatoEstudiante with id: {EstudianteId} doesn't exist in the database.")
    {
    }
}
