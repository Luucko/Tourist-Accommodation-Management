namespace TouristAccommodationManagement.Exceptions;

public class AccommodationNotFoundException : Exception
{
    public AccommodationNotFoundException(string message) : base(message) { }
}