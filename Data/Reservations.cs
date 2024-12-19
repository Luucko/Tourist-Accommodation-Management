using TouristAccommodationManagement.Exceptions;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Data
{
    /// <summary>
    /// Provides methods to manage reservations.
    /// </summary>
    public static class Reservations
    {
        private static List<Reservation> ReservationsList = new List<Reservation>(); // Save to file when needed

        /// <summary>
        /// Retrieves a reservation by its ID.
        /// </summary>
        /// <param name="id">The ID of the reservation.</param>
        /// <returns>The reservation if found, otherwise null.</returns>
        /// <exception cref="ReservationNotFoundException">Thrown when no reservation is found for the given ID.</exception>
        public static Reservation GetReservation(int id)
        {
            var reservation = ReservationsList.Find(r => r.GetId == id);
            if (reservation == null)
            {
                throw new ReservationNotFoundException($"Reservation with ID {id} not found.");
            }
            return reservation;
        }

        /// <summary>
        /// Removes a reservation from the list.
        /// </summary>
        /// <param name="reservation">The reservation to remove.</param>
        /// <returns>True if the reservation was successfully removed; otherwise, false.</returns>
        /// <exception cref="ReservationNotFoundException">Thrown when the reservation does not exist in the list.</exception>
        public static bool RemoveReservation(Reservation reservation)
        {
            if (!ReservationsList.Contains(reservation))
            {
                throw new ReservationNotFoundException("The reservation to remove was not found.");
            }

            ReservationsList.Remove(reservation);
            return true;
        }

        /// <summary>
        /// Gets the next available reservation ID.
        /// </summary>
        /// <returns>The next available reservation ID.</returns>
        public static int GetNextId()
        {
            return ReservationsList.Count + 1;
        }

        /// <summary>
        /// Retrieves all reservations in the list.
        /// </summary>
        /// <returns>A list of all reservations.</returns>
        public static List<Reservation> GetAllReservations()
        {
            return ReservationsList;
        }

        /// <summary>
        /// Clears all reservations from the list.
        /// </summary>
        /// <returns>True if the list was cleared successfully.</returns>
        public static bool ClearReservations()
        {
            ReservationsList.Clear();
            return true;
        }

        /// <summary>
        /// Adds a new reservation to the list.
        /// </summary>
        /// <param name="reservation">The reservation to add.</param>
        /// <returns>True if the reservation was added successfully; otherwise, false.</returns>
        /// <exception cref="ReservationAlreadyExistsException">Thrown when a reservation with the same ID already exists.</exception>
        public static bool AddReservation(Reservation reservation)
        {
            if (ReservationsList.Any(r => r.GetId == reservation.GetId))
            {
                throw new ReservationAlreadyExistsException($"Reservation with ID {reservation.GetId} already exists.");
            }

            ReservationsList.Add(reservation);
            return true;
        }
    }
}