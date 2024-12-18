namespace TouristAccommodationManagement.Exceptions;

public class CustomerException : ApplicationException
{
    public CustomerException() : base("Customer operation failed.") { }

    public CustomerException(string message) : base(message) { }

    public CustomerException(string message, Exception innerException) : base(message, innerException) { }
}