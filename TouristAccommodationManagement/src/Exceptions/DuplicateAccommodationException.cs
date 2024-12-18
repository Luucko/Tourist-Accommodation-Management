namespace TouristAccommodationManagement.Exceptions;

/// <summary>
/// Exception thrown when an attempt is made to add an accommodation that already exists.
/// </summary>
public class DuplicateAccommodationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DuplicateAccommodationException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public DuplicateAccommodationException(string message) : base(message) { }
}