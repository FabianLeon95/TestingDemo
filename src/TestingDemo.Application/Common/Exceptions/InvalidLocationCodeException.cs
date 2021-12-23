namespace TestingDemo.Application.Common.Exceptions
{
    public class InvalidLocationCodeException : Exception
    {
        public InvalidLocationCodeException(string message) : base(message)
        {
        }
    }
}
