namespace Entities.Exceptions
{
    public sealed class TelefonoAcudienteNotFoundException : NotFoundException
    {
        public TelefonoAcudienteNotFoundException(Guid telefonoAcudienteId)
            : base($"The TelefonoAcudiente with id: {telefonoAcudienteId} doesn't exist in the database.")
        {
        }
    }
}
