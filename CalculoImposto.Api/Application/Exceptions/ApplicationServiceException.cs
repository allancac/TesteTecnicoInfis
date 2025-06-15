namespace CalculoImposto.Api.Application.Exceptions
{
    public class  ApplicationServiceException : Exception
    {
        public ApplicationServiceException(string message, Exception? domainException = null)
            : base(message, domainException)
        {
        }
    }
}
