namespace TouristAccommodationManagement.Exceptions;

public class AccommodationException : ApplicationException
{
    public AccommodationException() : base("Accommodation operation failed.") { }

    public AccommodationException(string message) : base(message) { }

    public AccommodationException(string message, Exception innerException) : base(message, innerException) { }
}