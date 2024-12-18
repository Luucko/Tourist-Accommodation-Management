using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;
using System;
using System.Linq;

namespace TouristAccommodationManagement.Services
{
    public class ReservationRules
    {
        public static bool AddReservation(Reservation reservation)
        {
            if (!IsValidReservation(reservation))
            {
                return false;
            }

            Reservations.AddReservation(reservation);
            return true;
        }

        public static Reservation GetReservation(int id)
        {
            return Reservations.GetReservation(id);
        }

        public static bool RemoveReservation(Reservation reservation)
        {
            if (Reservations.GetReservation(reservation.GetId) == null)
            {
                return false;
            }

            Reservations.RemoveReservation(reservation);
            return true;
        }

        public static int GetNextId()
        {
            return Reservations.GetNextId();
        }

        public static List<Reservation> GetAllReservations()
        {
            return Reservations.GetAllReservations();
        }
        
        private static bool IsValidReservation(Reservation reservation)
        {
            bool validCheckinCheckout = reservation.GetCheckInDate < reservation.GetCheckOutDate;

            bool isOverlapping = Reservations.GetAllReservations().Any(existingReservation =>
                existingReservation.GetAccommodation.GetId == reservation.GetAccommodation.GetId && // Same accommodation
                existingReservation.GetStatus != ReservationStatus.Cancelled && // Not cancelled
                reservation.GetCheckOutDate > existingReservation.GetCheckInDate && // Overlaps start
                reservation.GetCheckInDate < existingReservation.GetCheckOutDate); // Overlaps end

            return validCheckinCheckout && !isOverlapping;
        }

        public static double CalculateTotalPrice(Reservation reservation)
        {
            int totalNights = (reservation.GetCheckOutDate - reservation.GetCheckInDate).Days;
            return totalNights * reservation.GetAccommodation.GetPricePerNight;
        }
    }
}
