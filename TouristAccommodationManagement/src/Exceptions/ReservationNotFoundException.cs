namespace TouristAccommodationManagement.Exceptions;

/// <summary>
/// Exception thrown when a reservation cannot be found.
/// </summary>
public class ReservationNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReservationNotFoundException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ReservationNotFoundException(string message) : base(message) { }
}