namespace Entities.Exceptions;

public class EstudianteDocumentosNotFoundException : NotFoundException
{
	public EstudianteDocumentosNotFoundException(Guid documentoId)
		: base($"Employee with id: {documentoId} doesn't exist in the database.")
	{
	}
}
