namespace TouristAccommodationManagement.Exceptions;

public class DuplicateAccommodationException : Exception
{
    public DuplicateAccommodationException(string message) : base(message) { }
}