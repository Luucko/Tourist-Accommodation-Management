using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Data
{
    public static class Reservations
    {
        private static List<Reservation> ReservationsList = new List<Reservation>(); // Save to file when needed

        public static Reservation GetReservation(int id)
        {
            return ReservationsList.Find(r => r.GetId == id);
        }

        public static bool RemoveReservation(Reservation reservation)
        {
            if (ReservationsList.Contains(reservation))
            {
                ReservationsList.Remove(reservation);
                return true;
            }
            return false;
        }

        public static int GetNextId()
        {
            return ReservationsList.Count + 1;
        }

        public static List<Reservation> GetAllReservations()
        {
            return ReservationsList;
        }

        public static bool ClearReservations()
        {
            ReservationsList.Clear();
            return true;
        }

        public static bool AddReservation(Reservation reservation)
        {
            if (ReservationsList.Any(r => r.GetId == reservation.GetId))
            {
                return false;
            }
            ReservationsList.Add(reservation);
            return true;
        }
    }
}