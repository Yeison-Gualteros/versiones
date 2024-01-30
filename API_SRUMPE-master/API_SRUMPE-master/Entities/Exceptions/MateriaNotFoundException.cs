namespace Entities.Exceptions;

public sealed class MateriaNotFoundException : NotFoundException
{
    public MateriaNotFoundException(Guid MateriaId)
        : base($"The Materia with id: {MateriaId} doesn't exist in the database.")
    {
    }
}