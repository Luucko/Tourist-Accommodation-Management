namespace TouristAccommodationManagement.Exceptions;

/// <summary>
/// Exception thrown when a customer cannot be found.
/// </summary>
public class CustomerNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerNotFoundException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public CustomerNotFoundException(string message) : base(message) { }
}