using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;
using System;
using System.Linq;
using TouristAccommodationManagement.Exceptions;

namespace TouristAccommodationManagement.Services
{
    /// <summary>
    /// Provides services for managing reservations.
    /// </summary>
    public class ReservationService
    {
        /// <summary>
        /// Adds a new reservation to the system.
        /// </summary>
        /// <param name="reservation">The reservation to add.</param>
        /// <returns>True if the reservation is successfully added.</returns>
        /// <exception cref="InvalidReservationException">Thrown when the reservation is invalid or overlaps with existing reservations.</exception>
        public static bool AddReservation(Reservation reservation)
        {
            if (!IsValidReservation(reservation))
            {
                throw new InvalidReservationException("The reservation is invalid or overlaps with an existing reservation.");
            }

            Reservations.AddReservation(reservation);
            return true;
        }

        /// <summary>
        /// Retrieves a reservation by ID.
        /// </summary>
        /// <param name="id">The ID of the reservation.</param>
        /// <returns>The reservation if found.</returns>
        /// <exception cref="ReservationNotFoundException">Thrown when no reservation is found for the given ID.</exception>
        public static Reservation GetReservation(int id)
        {
            var reservation = Reservations.GetReservation(id);
            if (reservation == null)
            {
                throw new ReservationNotFoundException($"Reservation with ID {id} not found.");
            }

            return reservation;
        }

        /// <summary>
        /// Removes a reservation from the system.
        /// </summary>
        /// <param name="reservation">The reservation to remove.</param>
        /// <returns>True if the reservation was removed successfully.</returns>
        /// <exception cref="ReservationNotFoundException">Thrown when no reservation is found for the given ID.</exception>
        public static bool RemoveReservation(Reservation reservation)
        {
            var existingReservation = Reservations.GetReservation(reservation.GetId);
            if (existingReservation == null)
            {
                throw new ReservationNotFoundException($"Reservation with ID {reservation.GetId} not found.");
            }

            Reservations.RemoveReservation(reservation);
            return true;
        }

        /// <summary>
        /// Gets the next available reservation ID.
        /// </summary>
        /// <returns>The next available ID.</returns>
        public static int GetNextId()
        {
            return Reservations.GetNextId();
        }

        /// <summary>
        /// Retrieves all reservations in the system.
        /// </summary>
        /// <returns>A list of all reservations.</returns>
        public static List<Reservation> GetAllReservations()
        {
            return Reservations.GetAllReservations();
        }

        /// <summary>
        /// Validates a reservation.
        /// </summary>
        /// <param name="reservation">The reservation to validate.</param>
        /// <returns>True if the reservation is valid; otherwise, false.</returns>
        private static bool IsValidReservation(Reservation reservation)
        {
            // Check for overlapping reservations in the same accommodation
            bool isOverlapping = Reservations.GetAllReservations().Any(existingReservation =>
                existingReservation.GetAccommodation.GetId == reservation.GetAccommodation.GetId && // Same accommodation
                existingReservation.GetStatus != ReservationStatus.Cancelled && // Not cancelled
                reservation.GetCheckOutDate > existingReservation.GetCheckInDate && // Overlaps start
                reservation.GetCheckInDate < existingReservation.GetCheckOutDate); // Overlaps end

            return !isOverlapping; // Return true if no overlap, false if overlapping
        }

        /// <summary>
        /// Calculates the total price of a reservation.
        /// </summary>
        /// <param name="reservation">The reservation for which the total price is calculated.</param>
        /// <returns>The total price of the reservation.</returns>
        /// <exception cref="InvalidReservationException">Thrown when the reservation's check-in or check-out dates are invalid.</exception>
        public static double CalculateTotalPrice(Reservation reservation)
        {
            if (reservation.GetCheckInDate >= reservation.GetCheckOutDate)
            {
                throw new InvalidReservationException("Invalid reservation dates: check-in date must be earlier than check-out date.");
            }

            int totalNights = (reservation.GetCheckOutDate - reservation.GetCheckInDate).Days;
            return totalNights * reservation.GetAccommodation.GetPricePerNight;
        }
    }
}
