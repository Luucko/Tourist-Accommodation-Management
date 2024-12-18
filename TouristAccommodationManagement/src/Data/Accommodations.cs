using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Data;

public class Accommodations
{
    private static List<Accommodation> AccommodationsList = new List<Accommodation>(); // Save to file when needed

    public static Accommodation GetAccommodation(int id)
    {
        return AccommodationsList.Find(a => a.GetId == id);
    }

    public static bool AddAccommodation(Accommodation accommodation)
    {
        if (AccommodationsList.Any(a => a.GetId == accommodation.GetId))
        {
            return false;
        }
        AccommodationsList.Add(accommodation);
        return true;
    }

    public static bool RemoveAccommodation(int id)
    {
        var accommodation = AccommodationsList.Find(a => a.GetId == id);
        if (accommodation != null)
        {
            AccommodationsList.Remove(accommodation);
            return true;
        }
        return false;
    }

    public static int GetNextId()
    {
        return AccommodationsList.Count + 1;
    }

    public static List<Accommodation> GetAllAccommodations()
    {
        return AccommodationsList;
    }

    public static bool ClearAccommodations()
    {
        AccommodationsList.Clear();
        return true;
    }
}