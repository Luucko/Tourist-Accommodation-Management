namespace TouristAccommodationManagement.Exceptions;

/// <summary>
/// Exception thrown when an attempt is made to create a reservation that already exists.
/// </summary>
public class ReservationAlreadyExistsException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReservationAlreadyExistsException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ReservationAlreadyExistsException(string message) : base(message) { }
}