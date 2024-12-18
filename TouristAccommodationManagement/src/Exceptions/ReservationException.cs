namespace TouristAccommodationManagement.Exceptions;

public class ReservationException : ApplicationException
{
    public ReservationException() : base("Reservation operation failed.") { }

    public ReservationException(string message) : base(message) { }

    public ReservationException(string message, Exception innerException) : base(message, innerException) { }
}