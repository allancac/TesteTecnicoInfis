namespace CalculoImposto.Api.Application.Exceptions
{
    public class  ApplicationException : Exception
    {
        public ApplicationException(string message, Exception? domainException = null)
            : base(message, domainException)
        {
        }
    }
}
