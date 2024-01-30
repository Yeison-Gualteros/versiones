namespace Entities.Exceptions;

public sealed class MateriaCollectionBadRequest : BadRequestException
{
    public MateriaCollectionBadRequest()
        : base("Materia collection sent from a client is null.")
    {
    }
}