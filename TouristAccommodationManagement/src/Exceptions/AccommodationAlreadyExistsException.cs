namespace TouristAccommodationManagement.Exceptions;

public class AccommodationAlreadyExistsException : Exception
{
    public AccommodationAlreadyExistsException(string message) : base(message) { }
}