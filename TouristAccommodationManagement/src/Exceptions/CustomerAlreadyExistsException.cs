namespace TouristAccommodationManagement.Exceptions;

/// <summary>
/// Exception thrown when a customer already exists in the system.
/// </summary>
public class CustomerAlreadyExistsException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerAlreadyExistsException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public CustomerAlreadyExistsException(string message) : base(message) { }
}