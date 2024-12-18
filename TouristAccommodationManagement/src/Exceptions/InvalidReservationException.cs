namespace TouristAccommodationManagement.Exceptions;

/// <summary>
/// Exception thrown when a reservation is considered invalid.
/// </summary>
public class InvalidReservationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidReservationException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InvalidReservationException(string message) : base(message) { }
}