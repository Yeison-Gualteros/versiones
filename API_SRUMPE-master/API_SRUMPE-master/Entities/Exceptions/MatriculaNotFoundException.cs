using Entities.Models;

namespace Entities.Exceptions;

public sealed class MatriculaNotFoundException : NotFoundException
{
    public MatriculaNotFoundException(Guid MatriculaId)
        : base($"The Matricula with id: {MatriculaId} doesn't exist in the database.")
    {
    }
}
