namespace TestingDemo.Application.Common.Exceptions
{
    public class InvalidLocationCodeException : Exception
    {
        public InvalidLocationCodeException()
        {
        }

        public InvalidLocationCodeException(string message) : base(message)
        {
        }

        public InvalidLocationCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
