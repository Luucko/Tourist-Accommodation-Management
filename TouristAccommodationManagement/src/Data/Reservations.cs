using TouristAccommodationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TouristAccommodationManagement.Data
{
    public static class Reservations
    {
        private static List<Reservation> ReservationsList = new List<Reservation>(); //save to file

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
            bool validCheckinCheckout = reservation.GetCheckInDate < reservation.GetCheckOutDate;
            
            bool isOverlapping = ReservationsList.Any(existingReservation =>
                existingReservation.GetAccommodation.GetId == reservation.GetAccommodation.GetId &&   // Same accommodation
                existingReservation.GetStatus != ReservationStatus.Cancelled &&                       // Not cancelled
                reservation.GetCheckOutDate > existingReservation.GetCheckInDate &&                   // Overlaps start
                reservation.GetCheckInDate < existingReservation.GetCheckOutDate);                    // Overlaps end
            
            if (reservation.GetStatus == ReservationStatus.Booked || reservation.GetStatus == ReservationStatus.CheckedIn)
            {
                // Valid if check-in is before check-out and no overlaps exist and other reservation is either booked or checked in
                return validCheckinCheckout && !isOverlapping;
            }
            
            return false; //custom exception in separate dll if using n-tier architecture
        }

        public static Reservation GetReservation(int id)
        {
            return ReservationsList.Find(r => r.GetId == id);
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
        
        public static void ClearReservations()
        {
            ReservationsList.Clear();
        }
    }
}
