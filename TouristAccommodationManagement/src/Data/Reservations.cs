using TouristAccommodationManagement.Models;
using System;
using System.Collections.Generic;

namespace TouristAccommodationManagement.Data
{
    public static class Reservations
    {
        private static List<Reservation> ReservationsList = new List<Reservation>(); // Save to file when needed

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
        
        public static void AddReservation(Reservation reservation)
        {
            ReservationsList.Add(reservation);
        }
    }
}