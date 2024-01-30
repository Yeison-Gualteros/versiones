namespace Entities.Exceptions;

public sealed class AcudienteNotFoundException : NotFoundException
{
    public AcudienteNotFoundException(Guid AcudienteId)
        : base($"The CandidatoEstudiante with id: {AcudienteId} doesn't exist in the database.")
    {
    }
}
