using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Services
{
    public class AccommodationRules
    {
        public static bool AddAccommodation(Accommodation accommodation)
        {
            if (Accommodations.GetAccommodation(accommodation.GetId) != null)
            {
                return false;
            }

            Accommodations.AddAccommodation(accommodation);
            return true;
        }

        public static Accommodation GetAccommodation(int id)
        {
            return Accommodations.GetAccommodation(id);
        }

        public static bool RemoveAccommodation(int id)
        {
            var accommodation = Accommodations.GetAccommodation(id);
            if (accommodation == null)
            {
                return false;
            }

            Accommodations.RemoveAccommodation(id);
            return true;
        }

        public static int GetNextId()
        {
            return Accommodations.GetNextId();
        }

        public static List<Accommodation> GetAllAccommodations()
        {
            return Accommodations.GetAllAccommodations();
        }

        public static bool UpdateAccommodation(Accommodation accommodation)
        {
            var existingAccommodation = Accommodations.GetAccommodation(accommodation.GetId);
            if (existingAccommodation == null)
            {
                return false;
            }

            Accommodations.RemoveAccommodation(accommodation.GetId);
            Accommodations.AddAccommodation(accommodation);
            return true;
        }
    }
}