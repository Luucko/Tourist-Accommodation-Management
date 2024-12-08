using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Data;

public static class Reservations
{
    private static List<Reservation> ReservationsList = new List<Reservation>();
    
    public static bool AddReservation(Reservation reservation)
    {
        // Check if any existing reservation overlaps with the new reservation
        bool isOverlapping = ReservationsList.Any(existingReservation =>
            existingReservation.Accommodation.ID == reservation.Accommodation.ID && // Same accommodation
            existingReservation.CheckInDate < reservation.CheckOutDate &&           // Overlapping dates
            existingReservation.CheckOutDate > reservation.CheckInDate);            // Overlapping dates

        if (isOverlapping)
        {
            return false; // Reservation failed due to overlap
        }

        ReservationsList.Add(reservation);
        return true; // Reservation added successfully
    }

    
    public static Reservation GetReservation(int id)
    {
        return ReservationsList.Find(r => r.Id == id);
    }
    
    public static void RemoveReservation(Reservation reservation)
    {
        ReservationsList.Remove(reservation);
    }
    
    public static int GetNextId()
    {
        return ReservationsList.Count + 1;
    }
    
    public static List<Reservation> GetAllReservations()
    {
        return ReservationsList;
    }

    public static void UpdateReservation(Reservation reservation)
    {
        var existingReservation = ReservationsList.Find(r => r.Id == reservation.Id);
        if (existingReservation == null)
        {
            throw new InvalidOperationException("Reservation not found.");
        }

        RemoveReservation(existingReservation);
        AddReservation(reservation);
    }
}