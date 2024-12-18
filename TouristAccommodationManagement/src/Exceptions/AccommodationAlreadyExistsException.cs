namespace TouristAccommodationManagement.Exceptions;

/// <summary>
/// Exception thrown when an attempt is made to add an accommodation that already exists.
/// </summary>
public class AccommodationAlreadyExistsException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccommodationAlreadyExistsException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public AccommodationAlreadyExistsException(string message) : base(message) { }
}