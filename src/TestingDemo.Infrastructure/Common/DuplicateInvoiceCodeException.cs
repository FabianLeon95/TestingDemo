namespace TestingDemo.Infrastructure.Common;

public class DuplicateInvoiceCodeException : ArgumentException
{
    public DuplicateInvoiceCodeException(string message, string paramName) : base(message, paramName)
    {
    }
}