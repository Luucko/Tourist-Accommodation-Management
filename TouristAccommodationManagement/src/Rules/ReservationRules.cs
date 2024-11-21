using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Services
{
    public class ReservationRules 
    {
        public static bool AddReservation(Reservation reservation)
        {
            // can check "Rules" here eg can't add reservation on these dates etc => shallow situational testing
            return Reservations.AddReservation(reservation);
        }
        
        public Reservation GetReservation(int id)
        {
            return Reservations.GetReservation(id);
        }
        
        public void RemoveReservation(Reservation reservation)
        {
            Reservations.RemoveReservation(reservation);
        }
        
        public static int GetNextId()
        {
            return Reservations.GetNextId();
        }

        public static List<Reservation> GetAllReservations()
        {
            return Reservations.GetAllReservations();
        }

        public static void UpdateReservation(Reservation reservation)
        {
            Reservations.UpdateReservation(reservation);
        }
    }
}