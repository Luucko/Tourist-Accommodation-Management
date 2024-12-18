namespace TouristAccommodationManagement.Exceptions;

public class ReservationNotFoundException : Exception
{
    public ReservationNotFoundException(string message) : base(message) { }
}