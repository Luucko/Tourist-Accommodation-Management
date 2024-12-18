namespace TouristAccommodationManagement.Exceptions;

/// <summary>
/// Exception thrown when a duplicate customer is encountered.
/// </summary>
public class DuplicateCustomerException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DuplicateCustomerException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public DuplicateCustomerException(string message) : base(message) { }
}