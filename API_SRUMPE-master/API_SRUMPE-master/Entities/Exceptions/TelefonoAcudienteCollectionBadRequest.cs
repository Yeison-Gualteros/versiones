namespace Entities.Exceptions
{
    public sealed class TelefonoAcudienteCollectionBadRequest : BadRequestException
    {
        public TelefonoAcudienteCollectionBadRequest()
            : base("TelefonoAcudiente collection sent from a client is null.")
        {
        }
    }
}
