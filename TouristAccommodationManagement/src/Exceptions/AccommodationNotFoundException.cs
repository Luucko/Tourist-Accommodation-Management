namespace TouristAccommodationManagement.Exceptions;

/// <summary>
/// Exception thrown when an accommodation cannot be found.
/// </summary>
public class AccommodationNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccommodationNotFoundException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public AccommodationNotFoundException(string message) : base(message) { }
}