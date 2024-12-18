namespace TouristAccommodationManagement.Exceptions;

public class InvalidReservationException : Exception
{
    public InvalidReservationException(string message) : base(message) { }
}