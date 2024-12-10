using TouristAccommodationManagement.Models;
using TouristAccommodationManagement.Services;

namespace TouristAccommodationManagement.Data;

public static class Reservations
{
    private static List<Reservation> ReservationsList = new List<Reservation>();
    
    public static bool AddReservation(Reservation reservation)
    {
        if (IsValidReservation(reservation))
        {
            ReservationsList.Add(reservation);
            return true;
        }
        return false;
    }

    private static bool IsValidReservation(Reservation reservation)
    {
        bool validCheckinCheckout = reservation.CheckInDate < reservation.CheckOutDate;
        
        bool isOverlapping = ReservationsList.Any(existingReservation =>
            existingReservation.Accommodation.ID == reservation.Accommodation.ID &&   // Same accommodation
            reservation.CheckOutDate > existingReservation.CheckInDate &&             // Overlaps start
            reservation.CheckInDate < existingReservation.CheckOutDate);              // Overlaps end
        
        if (reservation.Status == ReservationStatus.Booked || reservation.Status == ReservationStatus.CheckedIn)
        {
            // Valid if check-in is before check-out and no overlaps exist and other reservation is either booked or checked in
            return validCheckinCheckout && !isOverlapping;
        }
        
        return false;
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