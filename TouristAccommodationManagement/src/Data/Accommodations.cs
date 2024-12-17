using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Data;

public class Accommodations
{
    private static List<Accommodation> AccommodationsList = new List<Accommodation>();
    
    public static Accommodation GetAccommodation(int id)
    {
        return AccommodationsList.Find(a => a.GetId == id);
    }
    
    public static void AddAccommodation(Accommodation accommodation)
    {
        AccommodationsList.Add(accommodation);
    }
    
    public static void RemoveAccommodation(int id)
    {
        AccommodationsList.RemoveAll(a => a.GetId == id);
    }
    
    public static int GetNextId()
    {
        return AccommodationsList.Count + 1;
    }
    
    public static List<Accommodation> GetAllAccommodations()
    {
        return AccommodationsList;
    }
}