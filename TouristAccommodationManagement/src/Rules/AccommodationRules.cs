using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Services;

public class AccommodationRules
{
    public static void AddAccommodation(Accommodation accommodation)
    {
        Accommodations.AddAccommodation(accommodation);
    }
    
    public Accommodation GetAccommodation(int id)
    {
        return Accommodations.GetAccommodation(id);
    }
    
    public void RemoveAccommodation(int id)
    {
        Accommodations.RemoveAccommodation(id);
    }
    
    public static int GetNextId()
    {
        return Accommodations.GetNextId();
    }
    
    public List<Accommodation> GetAllAccommodations()
    {
        return Accommodations.GetAllAccommodations();
    }

    public static void UpdateAccommodation(Accommodation accommodation)
    {
        Accommodations.RemoveAccommodation(accommodation.ID);
        Accommodations.AddAccommodation(accommodation);
    }
}