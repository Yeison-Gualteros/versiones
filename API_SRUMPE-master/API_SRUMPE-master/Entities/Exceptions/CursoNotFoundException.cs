namespace Entities.Exceptions;

public sealed class CursoNotFoundException : NotFoundException
{
    public CursoNotFoundException(Guid CursoId)
        : base($"The Curso with id: {CursoId} doesn't exist in the database.")
    {
    }
}