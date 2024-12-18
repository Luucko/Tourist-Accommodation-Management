namespace TouristAccommodationManagement.Exceptions;

public class ReservationAlreadyExistsException : Exception
{
    public ReservationAlreadyExistsException(string message) : base(message) { }
}