namespace Entities.Exceptions;

public sealed class PreMatriculaNotFoundException : NotFoundException
{
    public PreMatriculaNotFoundException(Guid PreMatriculaId)
        : base($"The PreMatricula with id: {PreMatriculaId} doesn't exist in the database.")
    {
    }
}