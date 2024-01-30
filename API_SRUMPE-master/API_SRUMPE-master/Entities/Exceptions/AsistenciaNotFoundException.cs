namespace Entities.Exceptions;

public sealed class AsistenciaNotFoundException : NotFoundException
{
    public AsistenciaNotFoundException(int AsistenciaId)
        : base($"The CandidatoEstudiante with id: {AsistenciaId} doesn't exist in the database.")
    {
    }
}